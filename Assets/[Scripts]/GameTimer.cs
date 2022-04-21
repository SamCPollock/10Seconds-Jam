using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI bounceCountText;
    public Slider timeSlider;
    public RectTransform handleTransform;
    public GameObject winCanvas;
    public GameObject loseCanvas;


    public int bounceCount = 0;

    public float timeRemaining = 0f;

    public bool timeIsGoingForward = true;

    public AudioSource audioSource; 

    void Start()
    {
        audioSource.time = 49;
    }

    void Update()
    {
        if (timeIsGoingForward)
        {
            timeRemaining += Time.deltaTime;
            handleTransform.localScale = new Vector3(2, 2, 2);
        }

        else
        {
            timeRemaining -= Time.deltaTime;
            handleTransform.localScale = new Vector3(-2, 2, 2);
        }
        timerText.text = Mathf.RoundToInt(timeRemaining).ToString();
        timeSlider.value = timeRemaining;


        if (timeRemaining > 10 || timeRemaining < 0)
        {
            LoseGame();
        }

        if (bounceCount >= 10)
        {
            WinGame();
        }
    }

    public void ReverseTime(int timeSpeed)
    {
        bounceCount++;
        bounceCountText.text = bounceCount.ToString();
        audioSource.pitch = timeSpeed;
        if (timeSpeed == 1)
        {
            timeIsGoingForward = true;
        }
        else
        {
            timeIsGoingForward = false;
        }
    }

    void WinGame()
    {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
    }

    void LoseGame()
    {
        Time.timeScale = 0;
        loseCanvas.SetActive(true);

    }
}
