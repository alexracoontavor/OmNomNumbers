using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GridData {

    public static int KILLING_TILE_ID = -2;
    public static int VALUE_TILE_ID = -3;

    int[] grid;
	List<int> muncherIndexes = new List<int>();

    public GridData(){
		Reset();
	}
	
	public bool IsMuncherOnIndex (int index)
	{
		return muncherIndexes.IndexOf(index) != -1;
	}

	public void AddMuncher()
	{
		AddMuncherAt(UnityEngine.Random.Range(0, GameData.Instance.columns));
	}

	public void AddMuncherAt(int index)
	{
		if (muncherIndexes.IndexOf(index) != -1)
		{
			KillMuncherAt(index);
			ClearDeadMunchers();
		}
		else
		{
			muncherIndexes.Add(index);
		}
	}

	void KillMuncherAt (int index)
	{
        if (index >= 0 && index < muncherIndexes.Count)
            muncherIndexes[index] = -1;
    }

	int GetMoveVal ()
	{
		int answer = 1;

		if (GameData.Instance.direction == Direction.Down)
			answer = GameData.Instance.columns;
		else if (GameData.Instance.direction == Direction.Left)
			answer = -1;

		return answer;
	}

	public void Tick(){
		RepopulateScores();
		MoveAllMunchers();
		ApplyMunchersMoveResults();
	}

	void RepopulateScores ()
	{
		for (int i = 0; i < grid.Length; i++) {
			if (grid[i] == 0)
				grid[i] = GetRandomValue();
		}
	}

	void ApplyMunchersMoveResults ()
	{
		CollectScore();
	}

	void CollectScore ()
	{
		int score = 0;

		for (int i = 0; i < muncherIndexes.Count; i++) 
		{
			score += grid[muncherIndexes[i]];
			grid[muncherIndexes[i]] = 0;
		}

		GameData.Instance.score += score;
	}

	void MoveAllMunchers ()
	{
		int moveVal = GetMoveVal();
		
		for (int i = 0; i < muncherIndexes.Count; i++) {
			muncherIndexes[i] = MoveMuncher(muncherIndexes[i], moveVal, GameData.Instance.direction);
		}

		ClearDeadMunchers();
	}

	void ClearDeadMunchers ()
	{
		muncherIndexes = muncherIndexes.FindAll(x => x != -1);
	}

	int MoveMuncher (int index, int moveVal, Direction direction)
	{
        if (direction != Direction.Down)
        {
            index += GameData.Instance.columns;

            if (HitsSideWalls(index, moveVal))
            {
                moveVal = 0;
                grid[index - GameData.Instance.columns] = 0;
            }
        }

        if (CheckOutOfField(index, moveVal))
            return -1;
        else if (CheckKill(index, moveVal))
        {
            grid[index + moveVal] = GetRandomValue();
            return -1;
        }

        return index + moveVal;
	}

    public bool CheckKill(int index, int moveVal)
    {
        bool answer = false;

        if (index + moveVal < grid.Length)
        {
            if (grid[index + moveVal] == KILLING_TILE_ID)
                answer = true;
        }

        return answer;
    }

    private bool CheckOutOfField(int index, int moveVal)
    {
        bool answer = false;

        float newRow = (index + moveVal) / GameData.Instance.columns;

        if (newRow >= GameData.Instance.rows)
        {
            answer = true;
        }

        return answer;
    }

    private bool ChangesRows(int index, int moveVal)
    {
        return (index + moveVal) / GameData.Instance.columns != index / GameData.Instance.columns;
    }

    private bool HitsSideWalls(int index, int moveVal)
    {
        return ((index + moveVal < 0) || ChangesRows(index, moveVal));
    }

    public void Reset(){
		muncherIndexes.Clear();
		grid = new int[GameData.Instance.rows * GameData.Instance.columns];
		PopulateGridNumbers();
	}
	
	void PopulateGridNumbers ()
	{
		for (int i = 0; i < grid.Length; i++) {
			grid[i] = GetRandomValue();
		}
	}
	
	int GetRandomValue ()
	{
        int val = GameData.Instance.GetWeightedRandom(GameData.Instance.weightedTiles, GameData.Instance.tileTypes);

        if (val == VALUE_TILE_ID)
            val = GameData.Instance.GetWeightedRandom(GameData.Instance.weightedValues, GameData.Instance.values);

        return val;
	}

	public int[] GetGrid(){
		return grid;
	}
}
