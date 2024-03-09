using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactiveTargetPlayerOne : MonoBehaviour
{
    private int maxHealth = 30;
    private int currentHealth;

    public Text resultText;

    private void Start()
    {
        currentHealth = maxHealth;
        LogHealth();
    }

    public void ReactToHit()
    {
        currentHealth -= 6;

        // Ensure health doesn't go below 0
        currentHealth = Mathf.Max(currentHealth, 0);

        LogHealth();

        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);

        Time.timeScale = 0;

        resultText.text = "Player Two Wins!";

    }

    private void LogHealth()
    {
        Debug.Log("Player One's Health: " + currentHealth + " / " + maxHealth);
    }
}
