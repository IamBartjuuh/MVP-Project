using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public TextMeshProUGUI result;

    public GameObject reset;

    public string opponentChoice;
    public string playerChoice;

    public void PickRforOpponent()
    {
        var names = new List<string> { "Rock", "Paper", "Sissors" };

        int index = Random.Range(0, names.Count);
        opponentChoice = names[index];

        Result();
    }

    void Result()
    {
        if (playerChoice == opponentChoice)
        {
            result.text = "TIE!";
        }
        else if (playerChoice == "Rock")
        {
            if (opponentChoice == "Sissors")
            {
                result.text = "WIN!";
            }
            else
            {
                result.text = "LOSE!";
            }
        }
        else if (playerChoice == "Paper")
        {
            if (opponentChoice == "Sissors")
            {
                result.text = "LOSE!";
            }
            else
            {
                result.text = "WIN!";
            }
        }
        else if (playerChoice == "Sissors")
        {
            if (opponentChoice == "Paper")
            {
                result.text = "WIN!";
            }
            else { result.text = "LOSE!"; }
        }

        result.gameObject.SetActive(true);
        reset.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("Les1");
    }

    public void Animation(GameObject obj)
    {
        //obj.transform.rotation = 0.1;
    }

}
