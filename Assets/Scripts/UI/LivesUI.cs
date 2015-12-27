using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesUI : MonoBehaviour {

	public Text text;

	// Update is called once per frame
	void Update () {
		text.text = "Lives: " + GameData.Instance.livesLeft;
	}
}
