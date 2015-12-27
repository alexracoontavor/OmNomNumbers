using UnityEngine;
using System.Collections;
using System;

public enum Direction{Left,Right,Down};
public class GameData : Singleton<GameData> {

    public int[] tileTypes = new int[] {GridData.KILLING_TILE_ID, GridData.VALUE_TILE_ID };
    public int[] weightedTiles = new int[] {1, 100};
    public int[] weightedValues = new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1};
    public int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    public int score = 0;
	public int minVal = 1;
	public int maxVal = 10;
	public int rows = 5;
	public int columns = 5;
	public int livesLeft = 1;
    public int spawnTickRate = 3;
    public int startingLives = 50;
	public float startTickDuration = 0.2f;
	public float finalTickDuration = 0.05f;
	public float tickSpeedStep = 0.1f;
	public GridData gridData;
	public Direction direction = Direction.Down;
	
	public void Reset(){
		if (gridData == null)
			gridData = new GridData();

		gridData.Reset();
		livesLeft = startingLives;

		score = 0;
	}

    public int GetWeightedRandom(int[] weights, int[] values)
    {
        if (weights.Length != values.Length)
        {
            throw new Exception("Mismatching length of weights and values in GetWeightedRandom!");
        }

        int sum = 0;

        foreach (int val in weights)
        {
            sum += val;
        }

        int result = 0, total = 0;
        int randVal = UnityEngine.Random.Range(0, sum + 1);

        for (result = 0; result < weights.Length; result++)
        {
            total += weights[result];
            if (total >= randVal) break;
        }

        return values[result];
    }
}
