using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FuzePuzzle : MonoBehaviour, IPuzzle
{
    [SerializeField] private Slider _powerUpSlider;
    [SerializeField] private Item _rewardItem;
    [SerializeField] private GameObject UIBoard;

    public TMP_Text DeselectionText { get; set; }
    public bool CompleteFlag { get; set; }
    public IItem RewardItem => _rewardItem;
    public Player _player { get; set; }
    
    private float _timeToResetSlider = 2f;
    public Slider _CompletePuzzleSlider { get; set; }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        CompleteFlag = false;
        DeselectionText = GameObject.FindGameObjectWithTag(
            "DeselectionText").GetComponent<TMP_Text>();
        if (_powerUpSlider != null) 
            _powerUpSlider.value = 0;
        _CompletePuzzleSlider = GameObject.FindGameObjectWithTag(
            "CompletePuzzle").GetComponent<Slider>();
    }

    private void Update()
    {
        var dist = Vector3.Distance(transform.position,
            _player.transform.position);
        if(dist < 2) 
            Interact.InteractWithObject(
                UIBoard, _player, 
            gameObject, DeselectionText);
        
        if (Input.GetKey(KeyCode.G))
            _powerUpSlider.value += 1 * Time.deltaTime;
        else if (_timeToResetSlider < Time.deltaTime)
            _powerUpSlider.value -= 1 * Time.deltaTime;

        if (_powerUpSlider.value == _powerUpSlider.maxValue && !CompleteFlag)
        {
            CompleteFlag = true;
            _CompletePuzzleSlider.value += 1;
            gameObject.GetComponent<Outline>().OutlineColor = Color.green;
        }
    }
    
    public void NoRewardItem()
    {
        throw new System.NotImplementedException();
    }

}
