using TMPro;
using UnityEngine;

public class KeypadPuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private Item _rewardItem;
    [SerializeField] private int keyPadNumber;
    [SerializeField] private GameObject UIBoard;
    [SerializeField] private TMP_Text keyPadNumberText;
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public GameObject Player { get; }
    public string playerInputNumber;
    public int playerNumber = 0;
    


    private void Awake()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        keyPadNumber = NumberGeneration();
        keyPadNumberText.text = keyPadNumber.ToString();
    }

    private void Update()
    {
        if (playerNumber == keyPadNumber)
        {
            GiveRewardItem();
            CompleteFlag = true;
        }
    }

    private void GiveRewardItem() => Player.GetComponent<Inventory>().Equip(RewardItem);

    public int NumberGeneration() => Random.Range(10000,99999);

    public void NoRewardItem() => Debug.Log("Please add a reward item to be given on completion");

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            UIBoard.SetActive(!UIBoard.activeSelf);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            UIBoard.SetActive(false);
    }

    public void AddNumber(string numString)
    {
        playerInputNumber += numString;
        playerNumber = int.Parse(playerInputNumber);
    }

    public void NumberChanged() => playerInputNumber = "";
}
