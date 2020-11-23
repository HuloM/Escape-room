using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private float currentTime;

    private float startingTime = 60f;

    private TMP_Text timerText;

    public static bool outOfTime;
    public static Countdown _instance;
    
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        currentTime = startingTime;
        outOfTime = false;
        timerText = gameObject.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "Time Remaining: " + (int) currentTime + "s";

        if (currentTime <= 0)
        {
            outOfTime = true;
        }
    }
}
