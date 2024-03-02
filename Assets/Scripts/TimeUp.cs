using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{
    private float timeRemaining = 240; // 4 minutes in seconds

    public PlayerOneInventoryManager playerOneInventoryManager;
    public PlayerTwoInventoryManager playerTwoInventoryManager;

    public Text resultText;

    void Start()
    {
        StartCoroutine(CountdownToTimeUp());
    }

    public void DisplayScore()
    {
        int p1CombinedScore = 0;

        foreach (KeyValuePair<string, int> item in playerOneInventoryManager.items)
        {
            if (item.Key == "Player One Jumps")
            {
                p1CombinedScore += item.Value;
            }
            else if (item.Key == "Player One Collectibles")
            {
                p1CombinedScore += item.Value;
            }
        }

        int p2CombinedScore = 0;

        foreach (KeyValuePair<string, int> item in playerTwoInventoryManager.items)
        {
            if (item.Key == "Player Two Jumps")
            {
                p2CombinedScore += item.Value;
            }
            else if (item.Key == "Player Two Collectibles")
            {
                p2CombinedScore += item.Value;
            }
        }

        Debug.Log("Time is up!");
        Debug.Log("Player One's total: " + p1CombinedScore);
        Debug.Log("Player Two's total: " + p2CombinedScore);

        // Compare totals
        if (p1CombinedScore > p2CombinedScore)
        {
            Debug.Log("Player One wins!");
            resultText.text = "Player One Wins!";
        }
        else if (p2CombinedScore > p1CombinedScore)
        {
            Debug.Log("Player Two wins!");
            resultText.text = "Player Two Wins!";
        }
        else
        {
            Debug.Log("It's a draw!");
            resultText.text = "Draw!";
        }
    }

    IEnumerator CountdownToTimeUp()
    {
        while (timeRemaining > 0)
        {
            yield return null; // wait for the next frame
            timeRemaining -= Time.deltaTime; // decrease the time remaining
        }

        //freeze the game
        Time.timeScale = 0;

        DisplayScore();
    }

}