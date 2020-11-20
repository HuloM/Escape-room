using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeypadPuzzle : MonoBehaviour, IPuzzle
{
    
    
    [SerializeField] private Item _rewardItem;
    [SerializeField] private int keyPadNumber;
    [SerializeField] private GameObject UIBoard;
    [SerializeField] private TMP_Text keyPadNumberText;
    [SerializeField] private TMP_Text DeselectionText;
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }
    public string playerInputNumber;
    public int playerNumber = 0;
    


    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        keyPadNumber = NumberGeneration();
        keyPadNumberText.text = keyPadNumber.ToString();
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        Interact.InteractWithObject(
            UIBoard, _player, 
            gameObject, DeselectionText);

        if (playerNumber == keyPadNumber)
        {
            GiveRewardItem();
            CompleteFlag = true;
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

public class Interact
{
    public static void InteractWithObject(
        GameObject uiBoard, Player playergameObject, 
        GameObject interactionObject, TMP_Text tmpText)
    {
        var dist = Vector3.Distance(
            interactionObject.transform.position,
            playergameObject.transform.position);

        if (dist < 2 && PlayerInput.Instance.SelectionPressed)
            PuzzleIsActive(true, tmpText, uiBoard);
        else if (PlayerInput.Instance.DeSelectionPressed || dist > 2)
            PuzzleIsActive(false, tmpText, uiBoard);
    }

    private static void PuzzleIsActive(bool isActive, TMP_Text tmpText, GameObject uiBoard)
    {
        Cursor.lockState = isActive? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isActive;
        tmpText.enabled = isActive;
        uiBoard.SetActive(isActive);
    }
}