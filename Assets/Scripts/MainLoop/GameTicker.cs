using UnityEngine;
using System.Collections;
using System;

public delegate void TickComplete(TickCompleteAnswer onCompleteDelegate);
public delegate void TickCompleteAnswer();

public class GameTicker : MonoBehaviour {

	float tickTimer;
	bool isTicking = true;
	float currentTickDuration = 2f;

	public event TickComplete onTickComplete;

    void Start()
    {
        Reset();
    }

	public void Reset()
	{
		isTicking = true;
		currentTickDuration = GameData.Instance.startTickDuration;
	}
	
	void Update()
	{
		if (isTicking)
		{
			tickTimer += Time.deltaTime;
			
			if (tickTimer >= currentTickDuration)
			{
				TickComplete();
			}
		}
	}

	void HandleTickProcessingComplete(){
		isTicking = true;
	}

	void TickComplete ()
	{
		isTicking = false;
		
		tickTimer -= currentTickDuration;
		
		currentTickDuration = Math.Max(GameData.Instance.finalTickDuration, currentTickDuration-GameData.Instance.tickSpeedStep);
		
		if (onTickComplete != null)
		{
			onTickComplete(HandleTickProcessingComplete);
		}
	}
}
