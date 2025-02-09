using System;
using UnityEngine;

public class KeyboardInputDetector : MonoBehaviour
{
    public SelectOption player;
    public GameLogic logic;

    bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool pressedR = Input.GetKeyDown(KeyCode.R);
        bool pressedS = Input.GetKeyDown(KeyCode.S);
        bool pressedP = Input.GetKeyDown(KeyCode.P);
        bool pressedSpace = Input.GetKeyDown(KeyCode.Space);
        if (!isPressed)
        {
            if (pressedR)
            {
                player.SelectRock();
                isPressed = true;
            }
            else if (pressedS)
            {
                player.SelectSissors();
                isPressed = true;
            }
            else if (pressedP)
            {
                player.SelectPaper();
                isPressed = true;
            }
        }
        if (pressedSpace) {
            logic.Reset();
        }

    }
}
