using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapedScript : MonoBehaviour
{
    public GameObject winScreen;

    private Slider score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("CompletePuzzle").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (score.value >= 4)
        {
            winScreen.SetActive(true);
        }
    }
}
