using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    [SerializeField] private float startTime = 3f;

    private void Update()
    {
        if (PlayerData.SCORE < 0)
        {
            PlayerData.DISABLE_INPUT = true;
            UIMain9.Instance.ShowGameOver(true);

            if (Input.GetKey(KeyCode.R) && !PlayerData.START_GAME)
            {
                PlayerData.SCORE = 0;
                UIMain9.Instance.ShowGameOver(false);
                PlayerData.START_GAME = true;
            }
        }

        if (PlayerData.START_GAME)
        {
            DecreaseStartTime();
        }
    }

    private void DecreaseStartTime()
    {
        if (startTime > .5f)
        {
            startTime -= Time.deltaTime;
        }else
        {
            PlayerData.START_GAME = false;
            PlayerData.DISABLE_INPUT = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        UIMain9.Instance.ShowStartTime(startTime);
    }
}
