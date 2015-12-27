using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TileDisplay : MonoBehaviour {

	public Color lowestColor;
	public Color highestColor;
    public Color killColor;

	public Image background;
	public Text text;

	public void SetValue(int val)
	{
        if (val == GridData.KILLING_TILE_ID)
        {
            background.color = killColor;
            text.text = "DEATH";
        }
        else
        {
            float colorFactor = (float)val / (float)GameData.Instance.maxVal;

            background.color = Color.Lerp(lowestColor, highestColor, colorFactor);
            text.text = val.ToString();
        }
	}
}
