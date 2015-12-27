using UnityEngine;
using System.Collections;

public class ButtonsController : MonoBehaviour {

    public event TickComplete onTickComplete;

    // Update is called once per frame
    void Update () {

        bool isChanged = false;

        if (Input.GetButtonDown("Right"))
        {
            GameData.Instance.direction = Direction.Right;
            isChanged = true;
        }
		else if (Input.GetButtonDown("Left"))
        {
            GameData.Instance.direction = Direction.Left;
            isChanged = true;
        }
        /*
        else if (Input.GetButtonDown("Down"))
        {
            GameData.Instance.direction = Direction.Down;
            isChanged = true;
        }
        */
        if (isChanged && onTickComplete != null)
            onTickComplete(HandleTickProcessingComplete);
    }


    void HandleTickProcessingComplete()
    {
    }

}
