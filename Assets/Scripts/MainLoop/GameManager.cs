using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	GameTicker ticker;
	GridDisplay gridDisplay;
	MunchersManager munchersManager;
    ButtonsController buttons;

	void Start () {
		ticker = transform.GetOrAddComponent<GameTicker>();
		//ticker.onTickComplete += HandleTick;

        buttons = transform.GetOrAddComponent<ButtonsController>();
        buttons.onTickComplete += HandleTick;

		munchersManager = transform.GetOrAddComponent<MunchersManager>();
		gridDisplay = FindObjectOfType<GridDisplay>();

		GameData.Instance.Reset();
		gridDisplay.Reset();
	}

	/// <summary>
	///	Distributes Tick calls, collects onComplete callbacks
	/// </summary>
	/// <param name="onCompleteDelegate">On complete delegate.</param>
	void HandleTick (TickCompleteAnswer onCompleteDelegate)
	{
		GameData.Instance.gridData.Tick();
		munchersManager.Tick();
		gridDisplay.UpdateTiles();
		onCompleteDelegate();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
