using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartTilesManager : MonoBehaviour {
	public GridLayoutGroup gridLayout;
	public GameObject tilePrefab;
	
	public void Reset(){
		ClearTiles();
		PopulateTiles();
	}
	
	void ClearTiles ()
	{
		foreach (Transform child in gridLayout.transform)
		{
			Destroy(child);
		}
	}
	
	void PopulateTiles ()
	{
		for (int i = 0; i < GameData.Instance.rows; i++) {
			GameObject go = Instantiate(tilePrefab);
			go.transform.SetParent(gridLayout.transform, false);
		}
	}
}
