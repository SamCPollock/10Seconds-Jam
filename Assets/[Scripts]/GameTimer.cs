using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Slider timeSlider;
    public RectTransform handleTransform;

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

    }

    public void ReverseTime(int timeSpeed)
    {
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
}
