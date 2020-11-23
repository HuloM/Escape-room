using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RetrivePuzzle : MonoBehaviour, IPuzzle
{
    public bool CompleteFlag { get; set; }
    public IItem RewardItem { get; }
    public Player _player { get; set; }
    public TMP_Text DeselectionText { get; set; }

    private void Start()
    {
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag(
            "DeselectionText").GetComponent<TMP_Text>();
        _player = FindObjectOfType<Player>();
        _CompletePuzzleSlider = GameObject.FindGameObjectWithTag(
            "CompletePuzzle").GetComponent<Slider>();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, 
            _player.transform.position);
        
        if (PlayerInput.Instance.SelectionPressed && !CompleteFlag && dist < 2)
        {
            CompleteFlag = true;
            _CompletePuzzleSlider.value += 1;
        }
    }

    public void NoRewardItem()
    {
        throw new System.NotImplementedException();
    }

    public Slider _CompletePuzzleSlider { get; set; }
}
