using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{
    [SerializeField ]int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
       if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
       else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int Getscore()
    {
        return score;
    }

    public void AddToScore( int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
