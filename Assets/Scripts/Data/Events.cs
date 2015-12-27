using UnityEngine;
using System.Collections;

public delegate void ScoreCollected(int scoreToAdd);

public class Events {

	public static event ScoreCollected onScoreCollected;

	public static void NotifyScoreCollected(int scoreToAdd)
	{
		if (onScoreCollected != null)
			onScoreCollected(scoreToAdd);
	}
}
