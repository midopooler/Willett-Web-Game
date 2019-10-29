using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketInstantiate : MonoBehaviour
{

    Transform Rocket;

    [SerializeField]
    Transform RocketPrefab;

    
    public Text ScoreText;

    public int ScoreValue = 0;

    [SerializeField]
    Text TimerObj;

    public float TimerValue = 60;
    string TimerToString;

    [SerializeField]
    GameObject GameOverPanel;

    [SerializeField]
    Text FinalText;

    void Update()
    {
        if(TimerValue <= 0)
        {
            if(GameOverPanel.gameObject.activeInHierarchy == false)
            {
                FinalText.text = ScoreValue.ToString();

                GameOverPanel.SetActive(true);
            }
            return;
        }


        if(Rocket == null)
        {
            Rocket = Instantiate(RocketPrefab, transform.position, Quaternion.identity);
        }
        Score();

        TimerValue -= Time.deltaTime;
        if (TimerValue >= 10)
        {
            TimerToString = TimerValue.ToString().Substring(0, 2);
        }
        else
        {
            TimerToString = TimerValue.ToString().Substring(0, 1);
        }
        TimerObj.text = TimerToString;

    }

    public void Score()
    {
        if (ScoreValue >= 0)
        {
            ScoreText.text = "Score: " + ScoreValue.ToString();
        }
    }

    public void Reset()
    {
        ScoreValue = 0;
        TimerValue = 60;
        GameOverPanel.gameObject.SetActive(false);
    }
}
