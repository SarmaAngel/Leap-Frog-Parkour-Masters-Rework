using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerPlayerTwo : MonoBehaviour
{
    [SerializeField]
    private Text _playerTwoScoreText;

    [SerializeField]
    private int _playerTwoScore;

    private JumpOverTally jumpOverTally;
    private Collectible collectible;

    private int _lastKnownJumps;
    private int _lastKnownCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        jumpOverTally = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpOverTally>();
        collectible = GameObject.FindGameObjectWithTag("Collect").GetComponent<Collectible>();
        
        _playerTwoScoreText.text = "Player Two: " + 0;
    }

    // Update is called once per frame

    void Update()
    {
        int currentJumps = jumpOverTally.GetPlayerTwoJumps();
        int currentCollectibles = collectible.GetPlayerTwoCollectibles();

        if (currentJumps > _lastKnownJumps)
        {
            _playerTwoScore += (currentJumps - _lastKnownJumps);
            _lastKnownJumps = currentJumps;
        }

        if (currentCollectibles > _lastKnownCollectibles)
        {
            _playerTwoScore += (currentCollectibles - _lastKnownCollectibles);
            _lastKnownCollectibles = currentCollectibles;
        }

        _playerTwoScoreText.text = "Player Two: " + _playerTwoScore.ToString();
    }

    /*void Update()
    {
        _playerTwoScore += (jumpOverTally.GetPlayerTwoJumps() + collectible.GetPlayerTwoCollectibles());
        _playerTwoScoreText.text = "Player Two: " + _playerTwoScore.ToString();
    }*/
}
