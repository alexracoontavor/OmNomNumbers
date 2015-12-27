using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUI : MonoBehaviour {

	public Text text;

	// Update is called once per frame
	void Update () {
		text.text = "Score: " + GameData.Instance.score.ToString();
	}
}
