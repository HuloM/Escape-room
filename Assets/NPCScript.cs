using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPCScript : MonoBehaviour, IPuzzle
{
    
    
    [SerializeField] private Item _rewardItem;
    [SerializeField] private GameObject UIBoard;

    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }



    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag("DeselectionText").GetComponent<TMP_Text>();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Interact.InteractWithObject(
            UIBoard, _player, 
            gameObject, DeselectionText);
    }

    public void NoRewardItem() => Debug.Log(
        "Please add a reward item to be given on completion");
    
}