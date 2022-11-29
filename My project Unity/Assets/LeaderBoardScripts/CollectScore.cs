using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScore : MonoBehaviour
{
    public ScoreManager scoreManager;
    public float totalScore;
    PlayerName playername = new PlayerName();

    void Start()
    {
        totalScore = GameStats.accuracy * GameStats.targetsHit;
        scoreManager.AddScore(new Score(PlayerController.playerName, totalScore));
    }

}
