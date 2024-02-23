using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerPlayerOne : MonoBehaviour
{
    [SerializeField]
    private Text _playerOneScoreText;

    [SerializeField]
    private int _playerOneScore;

    [SerializeField]
    private JumpOverTally jumpOverTally;

    [SerializeField]
    private Collectible collectible;

    private int _lastKnownJumps;
    private int _lastKnownCollectibles;

    // Start is called before the first frame update
    void Start()
    {
        jumpOverTally = GameObject.FindGameObjectWithTag("Player").GetComponent<JumpOverTally>();
        collectible = GameObject.FindGameObjectWithTag("Collect").GetComponent<Collectible>();

        _playerOneScoreText.text = "Player One: " + 0;
    }

    // Update is called once per frame
    
    void Update()
    {
        int currentJumps = jumpOverTally.GetPlayerOneJumps();
        int currentCollectibles = collectible.GetPlayerOneCollectibles();

        if (currentJumps > _lastKnownJumps)
        {
            _playerOneScore += (currentJumps - _lastKnownJumps);
            _lastKnownJumps = currentJumps;
        }

        if (currentCollectibles > _lastKnownCollectibles)
        {
            _playerOneScore += (currentCollectibles - _lastKnownCollectibles);
            _lastKnownCollectibles = currentCollectibles;
        }

        _playerOneScoreText.text = "Player One: " + _playerOneScore.ToString();
    }

    /*void Update()
    {
        _playerOneScore += (jumpOverTally.GetPlayerOneJumps() + collectible.GetPlayerOneCollectibles());
        _playerOneScoreText.text = "Player One: " + _playerOneScore.ToString();
    }*/
}
