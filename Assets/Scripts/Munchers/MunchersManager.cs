using UnityEngine;
using System.Collections;

public class MunchersManager : MonoBehaviour {

	int ticksFromSpawnCount = 0;

	/// <summary>
	/// Resets Munchers
	/// </summary>
	public void Reset(){
		ticksFromSpawnCount = 0;
	}

	public void Tick(){
		if (++ticksFromSpawnCount >= GameData.Instance.spawnTickRate && GameData.Instance.livesLeft > 0)
		{
			ticksFromSpawnCount = 0;
			GameData.Instance.livesLeft--;
			GameData.Instance.gridData.AddMuncher();
		}
	}
}
