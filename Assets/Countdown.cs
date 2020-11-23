using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    private float currentTime;

    private float startingTime = 60f;

    private TMP_Text timerText;

    public bool outOfTime = false;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
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
