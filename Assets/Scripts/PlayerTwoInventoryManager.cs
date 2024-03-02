using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoInventoryManager : MonoBehaviour, IGameManager

{
    public ManagerStatus status {get; private set;}
    public Dictionary<string, int> items;

    [SerializeField]
    private Text _playerTwoJumpsText;

    [SerializeField]
    private Text _playerTwoCollectText;

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");

        items = new Dictionary<string, int>();

        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, int> item in items)
        {
            itemDisplay += item.Key + "(" + item.Value + ") ";

            if (item.Key == "Player Two Collectibles")
            {
                _playerTwoCollectText.text = "P2 Collect: " + item.Value.ToString();
            }

            if (item.Key == "Player Two Jumps")
            {
                _playerTwoJumpsText.text = "P2 Jumps: " + item.Value.ToString();
            }
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name] += 1;
        }
        else
        {
            items[name] = 1;
        }

        DisplayItems();
    }

    //UI edit below
    public List<string> GetItemsList()
    {
        List<string> itemList = new List<string>(items.Keys);
        return itemList;
    }

    public int GetItemCount(string name)
    {
        if (items.ContainsKey(name))
        {
            return items[name];
        }
        return 0;
    }
}