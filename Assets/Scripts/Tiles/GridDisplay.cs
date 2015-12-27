using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridDisplay : MonoBehaviour {
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
		int[] grid = GameData.Instance.gridData.GetGrid();

        gridLayout.constraintCount = GameData.Instance.columns;

        for (int i = 0; i < grid.Length; i++) {
			GameObject go = Instantiate(tilePrefab);
			TileDisplay tile = go.GetComponentInChildren<TileDisplay>();
			tile.SetValue(grid[i]);
			go.transform.SetParent(gridLayout.transform, false);
		}
	}

	public void UpdateTiles(){
		int[] grid = GameData.Instance.gridData.GetGrid();

		for (int i = 0; i < grid.Length; i++) 
		{
			TileDisplay td = gridLayout.transform.GetChild(i).GetComponent<TileDisplay>();
			td.SetValue(grid[i]);

			if (GameData.Instance.gridData.IsMuncherOnIndex(i))
			{
				td.background.color = Color.white;
			}
		}
	}
}
