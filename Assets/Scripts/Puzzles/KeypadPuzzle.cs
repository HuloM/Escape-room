using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class KeypadPuzzle : MonoBehaviour, IPuzzle
{
    
    
    [SerializeField] private Item _rewardItem;
    [SerializeField] private int keyPadNumber;
    [SerializeField] private GameObject UIBoard;
    [SerializeField] private TMP_Text keyPadNumberText;
    
    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }
    public string playerInputNumber;
    public int playerNumber = 0;
    public Slider _CompletePuzzleSlider { get; set; }

    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag(
            "DeselectionText").GetComponent<TMP_Text>();
        keyPadNumber = NumberGeneration();
        keyPadNumberText.text = keyPadNumber.ToString();
        _player = FindObjectOfType<Player>();
        _CompletePuzzleSlider = GameObject.FindGameObjectWithTag("CompletePuzzle").GetComponent<Slider>();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position, 
            _player.transform.position);
        if(dist < 5)
            Interact.InteractWithObject(
                UIBoard, _player, 
            gameObject, DeselectionText);

        if (playerNumber == keyPadNumber && !CompleteFlag)
        {
            CompleteFlag = true;
            _CompletePuzzleSlider.value += 1;
        }
    }

    private void GiveRewardItem() => _rewardItem.gameObject.SetActive(true);

    public int NumberGeneration() => Random.Range(10000,99999);

    public void NoRewardItem() => Debug.Log(
        "Please add a reward item to be given on completion");


    public void AddNumber(string numString)
    {
        playerInputNumber = numString;
        playerNumber = Int32.Parse(playerInputNumber);
    }

    public void NumberChanged() => playerInputNumber = "";
}