using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerLights : MonoBehaviour, IPuzzle
{
    [SerializeField] private GameObject lights;
    
    private Item flashdrive;
    public bool hasFlashdrive => flashdrive != null;
    public IItem RewardItem { get; }
    public Player _player { get; set; }
    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public Slider _CompletePuzzleSlider { get; set; }

    public void Start()
    {
        if(RewardItem == null)
            NoRewardItem();
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag(
            "DeselectionText").GetComponent<TMP_Text>();
        _player = FindObjectOfType<Player>();
        _CompletePuzzleSlider = GameObject.FindGameObjectWithTag("CompletePuzzle").GetComponent<Slider>();

    }
    public void Update()
    {
        var dist = Vector3.Distance(gameObject.transform.position, _player.transform.position);
        if (_player.GetComponent<Inventory>().GetItemInSlot(0) != null 
            && PlayerInput.Instance.SelectionPressed 
            && dist < 2
            && !CompleteFlag)
        {
            flashdrive = _player.GetComponent<Inventory>().GetItemInSlot(0);
            lights.SetActive(true);
            _CompletePuzzleSlider.value += 1f;
        }
            
    }
    public void NoRewardItem()
    {
        throw new NotImplementedException();
    }

}