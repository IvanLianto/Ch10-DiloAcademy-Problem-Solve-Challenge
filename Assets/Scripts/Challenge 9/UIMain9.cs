using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMain9 : MonoBehaviour
{
    public static UIMain9 Instance;
    [SerializeField] private Text timeText;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowStartTime(float time)
    {
        if (time > .5f)
        {
            timeText.gameObject.SetActive(true);
            timeText.text = time.ToString("0");
        }
        else
        {
            PlayerData.DISABLE_INPUT = false;
            timeText.gameObject.SetActive(false);
        }
    }

    public void ShowGameOver(bool flag)
    {
        gameOverPanel.SetActive(flag);
    }

}
