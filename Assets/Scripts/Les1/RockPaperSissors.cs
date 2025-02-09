using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine.SceneManagement;

public class RockPaperSissors : MonoBehaviour
{
    public GameObject allButton;
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI opponentText;
    public TextMeshProUGUI result;

    public GameObject reset; 

    string opponentChoice;
    string playerChoice;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickedRock()
    {
        playerText.text = "Rock";
        playerChoice = playerText.text;
        playerText.gameObject.SetActive(true);
        ChangeButtonState(false);
    }
    public void ClickedPaper()
    {
        playerText.text = "Paper";
        playerChoice = playerText.text;
        playerText.gameObject.SetActive(true);
        ChangeButtonState(false);
    }
    public void ClickedSissors()
    {
        playerText.text = "Sissors";
        playerChoice = playerText.text;
        playerText.gameObject.SetActive(true);
        ChangeButtonState(false);
    }
    void ChangeButtonState(bool state)
    {
        this.allButton.SetActive(state);
        PickRforOpponent();
    }
    void PickRforOpponent()
    {
        var names = new List<string> { "Rock", "Paper", "Sissors" };

        int index = Random.Range(0, names.Count);
        opponentChoice = names[index];
        opponentText.text = opponentChoice;

        Result();
    }

    void Result()
    {
        if (playerChoice == opponentChoice)
        {
            result.text = "It is a TIE!";
        }
        else if (playerChoice == "Rock") { 
            if (opponentChoice == "Sissors")
            {
                result.text = "Player wins!";
            } else {
                result.text = "Opponent wins!";
            }
        } else if (playerChoice == "Paper") {
            if (opponentChoice == "Sissors")
            {
                result.text = "Opponent wins!";
            } else {
                result.text = "Player wins!";
            }
        } else if (playerChoice == "Sissors"){
            if(opponentChoice == "Paper")
            {
                result.text = "Player wins!";
            } else { result.text = "Opponent wins!"; }
        }

        result.gameObject.SetActive(true);
        reset.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("Les1");   
    }

}
