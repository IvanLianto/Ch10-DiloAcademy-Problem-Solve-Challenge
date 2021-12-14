using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        PlayerData.SCORE = 0;
    }

    public void SetScore(int amount, ScoreState state)
    {
        switch (state)
        {
            case ScoreState.ADD:
                PlayerData.SCORE += amount;
                break;
            case ScoreState.SUBSTRACT:
                PlayerData.SCORE -= amount;
                break;
        }
    }
}

public enum ScoreState
{
    ADD,
    SUBSTRACT
}
