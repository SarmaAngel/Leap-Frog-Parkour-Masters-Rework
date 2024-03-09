using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnePlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status {get; private set;}

    public int health {get; private set;}
    public int maxHealth {get; private set;}

    public void Startup()
    {
        Debug.Log("Player One manager starting...");

        health = 15;
        maxHealth = 15;

        status = ManagerStatus.Started;
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            Debug.Log("Player One is dead!");
        }

        Debug.Log($"Player One Health: {health} / {maxHealth}");
    }
}
