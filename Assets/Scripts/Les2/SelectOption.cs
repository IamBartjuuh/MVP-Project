using System.Diagnostics;
using UnityEngine;

public class SelectOption : MonoBehaviour
{
    public GameObject rock;
    public GameObject paper;
    public GameObject sissors;
    public bool isOpponent;
    public GameLogic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Update()
    {
        if (isOpponent && logic.playerChoice != "")
        {
            if (logic.opponentChoice == "Rock")
            {
                SelectRock();
            } else if (logic.opponentChoice == "Sissors")
            {
                SelectSissors();
            } else if (logic.opponentChoice == "Paper")
            {
                SelectPaper();
            }
        }
    }
    public void SelectRock()
    {
        paper.SetActive(false);
        sissors.SetActive(false);
        if (!isOpponent)
        {
            logic.playerChoice = "Rock";
            logic.PickRforOpponent();
        }
    }
    public void SelectPaper()
    {
        rock.SetActive(false);
        sissors.SetActive(false);
        if (!isOpponent)
        {
            logic.playerChoice = "Paper";
            logic.PickRforOpponent();
        }
    }
    public void SelectSissors()
    {
        rock.SetActive(false);
        paper.SetActive(false);
        if (!isOpponent)
        {
            logic.playerChoice = "Sissors";
            logic.PickRforOpponent();
        }
    }
}
