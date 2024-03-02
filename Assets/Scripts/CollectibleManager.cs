using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
   private List<GameObject> collectibles = new List<GameObject>();

    void Start()
    {
        GameObject[] foundCollectibles = GameObject.FindGameObjectsWithTag("Collect");
        foreach (GameObject collectible in foundCollectibles)
        {
            if (collectible.name != "Collect Temp")
            {
                collectibles.Add(collectible);
                collectible.SetActive(false); // setting all collectibles to be inactive
            }
            else
            {
                collectible.SetActive(true); // setting "Collect Temp" to be active
            }
        }

        StartCoroutine(ActivateCollectibles());

        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(false);
        }
    }

    IEnumerator ActivateCollectibles()
    {
        for (int i = 0; i < collectibles.Count; i++)
        {
            GameObject collectible = collectibles[i];
            if (collectible != null)
            {
                collectible.SetActive(true);
                yield return new WaitForSeconds(15);
                collectible.SetActive(false);
                collectibles.Remove(collectible);
                i--; // Decrement the index as we have removed an item from the list
            }
        }
    }
}

    /*void Start()
    {
        GameObject[] foundCollectibles = GameObject.FindGameObjectsWithTag("Collect");
        foreach (GameObject collectible in foundCollectibles)
        {
            collectibles.Add(collectible);
            collectible.SetActive(true); //seting all collectibles to be inactive
        }

        collectibles[0].SetActive(true); //set the first collectible to be active


        StartCoroutine(ActivateCollectibles());

        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }
    }

    IEnumerator ActivateCollectibles()
    {
        collectibles[0].SetActive(true);

        for (int i = 0; i < collectibles.Count; i++)
        {
            GameObject collectible = collectibles[i];
            if (collectible != null)
            {
                collectible.SetActive(true);
                yield return new WaitForSeconds(15);
                collectible.SetActive(false);
                collectibles.Remove(collectible);
                i--; // Decrement the index as we have removed an item from the list
            }
        }
    }
}*/
