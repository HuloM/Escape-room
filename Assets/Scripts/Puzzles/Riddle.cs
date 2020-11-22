using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Riddle : MonoBehaviour, IPuzzle
{
    
    
    [SerializeField] private Item _rewardItem;
    [SerializeField] private string answer;
    [SerializeField] private GameObject UIBoard;

    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }
    public string playerAnswer;



    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
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
        if(dist < 3)
            Interact.InteractWithObject(
                UIBoard, _player, 
            gameObject, DeselectionText);

        if (playerAnswer.Equals(answer, StringComparison.OrdinalIgnoreCase) && !CompleteFlag)
        {
            CompleteFlag = true;
            gameObject.GetComponent<Outline>().OutlineColor = Color.green;
            _CompletePuzzleSlider.value += 1f;
        }
    }

    private void GiveRewardItem() => _rewardItem.gameObject.SetActive(true);

    public void NoRewardItem() => Debug.Log(
        "Please add a reward item to be given on completion");

    public Slider _CompletePuzzleSlider { get; set; }

    public void SubmitAnswer(string answer2)
    {
        playerAnswer = answer2;
    }

    public void StringChanged() => playerAnswer = "";
}