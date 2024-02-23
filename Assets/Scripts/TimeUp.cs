using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUp : MonoBehaviour
{
    private float timeRemaining = 240; // 4 minutes in seconds

    public JumpOverTally jumpOverTally;
    public Collectible collectible;

    public Text resultText;

    void Start()
    {
        jumpOverTally = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpOverTally>();
        collectible = GameObject.FindGameObjectWithTag("Collect").GetComponent<Collectible>();

        if (jumpOverTally == null || collectible == null)
        {
            Debug.LogError("JumpOverTally or Collectible script not found!");
            return;
        } 

        StartCoroutine(CountdownToTimeUp());
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

        // Time is up, calculate the totals
        int total = jumpOverTally.GetPlayerOneJumps() + collectible.GetPlayerOneCollectibles();
        int total2 = jumpOverTally.GetPlayerTwoJumps() + collectible.GetPlayerTwoCollectibles();

        Debug.Log("Time is up!");
        Debug.Log("Player One's total: " + total);
        Debug.Log("Player Two's total: " + total2);

            // Compare totals
            if (total > total2)
            {
                Debug.Log("Player One wins!");
                resultText.text = "Player One Wins!";
            }
            else if (total2 > total)
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
}
