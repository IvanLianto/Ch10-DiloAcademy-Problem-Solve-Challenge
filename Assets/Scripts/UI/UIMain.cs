using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMain : MonoBehaviour
{
    public static UIMain Instance;

    [SerializeField] private Text scoreText;

    private void Awake()
    {
        Instance = this;

        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = $"Score : {PlayerData.SCORE}";
    }
}
