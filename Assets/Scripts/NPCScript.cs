using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class NPCScript : MonoBehaviour, IPuzzle
{
    
    
    [SerializeField] private Item _rewardItem;
    [SerializeField] private GameObject UIBoard;

    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }

    public Animator[] Animators;
    private static readonly int TalkedWithNpc = Animator.StringToHash("talked_with_npc");

    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag("DeselectionText").GetComponent<TMP_Text>();
        _player = FindObjectOfType<Player>();
        _CompletePuzzleSlider = GameObject.FindGameObjectWithTag(
            "CompletePuzzle").GetComponent<Slider>();
    }

    private void Update()
    {
        Interact.InteractWithObject(
            UIBoard, _player, 
            gameObject, DeselectionText);
        if (PlayerInput.Instance.SelectionPressed)
        {
            foreach (Animator animator in Animators)
                animator.SetBool(TalkedWithNpc, true);
            _CompletePuzzleSlider.value += 1f;
        }
    }

    public void NoRewardItem() => Debug.Log(
        "Please add a reward item to be given on completion");

    public Slider _CompletePuzzleSlider { get; set; }
}