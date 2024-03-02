using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpOverTally : MonoBehaviour
{
    public float raycastDistance = 15.0f; // You can adjust the raycast distance to your liking
    public float jumpCooldownDuration = 1.0f; // Duration of the cooldown period after each jump

    public static int playerOneJumps = 0; // Counter for Player One's jumps
    public static int playerTwoJumps = 0; // Counter for Player Two's jumps

    private float playerOneJumpCooldown = 0.0f; // Cooldown for Player One's jumps
    private float playerTwoJumpCooldown = 0.0f; // Cooldown for Player Two's jumps

    void Update()
    {
        // Decrease the cooldowns if they are greater than zero
        if (playerOneJumpCooldown > 0) playerOneJumpCooldown -= Time.deltaTime;
        if (playerTwoJumpCooldown > 0) playerTwoJumpCooldown -= Time.deltaTime;

        // Create a ray that points downwards from the player
        Ray ray = new Ray(transform.position, -transform.up);

        RaycastHit hit;

        // Cast the ray and check if it hits a collider
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the hit object's name is "Player One"
            if (hit.collider.gameObject.name == "Player One" && playerTwoJumpCooldown <= 0)
            {
                // Increment Player Two's jump counter and start the cooldown
                playerTwoJumpCooldown = jumpCooldownDuration;

                Managers.PlayerTwoInventory.AddItem("Player Two Jumps");

            }
            // Check if the hit object's name is "Player Two"
            else if (hit.collider.gameObject.name == "Player Two" && playerOneJumpCooldown <= 0)
            {
                // Increment Player One's jump counter and start the cooldown
                playerOneJumpCooldown = jumpCooldownDuration;

                Managers.PlayerOneInventory.AddItem("Player One Jumps");

            }
        }
    }

    public int GetPlayerOneJumps()
    {
        return playerOneJumps;
    }

    public int GetPlayerTwoJumps()
    {
        return playerTwoJumps;
    }
}