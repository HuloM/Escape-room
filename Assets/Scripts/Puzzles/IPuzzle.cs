using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IPuzzle
{
    bool CompleteFlag { get; set; }
    
    IItem RewardItem { get; }
    Player _player { get; set; }
    TMP_Text DeselectionText { get; set; }
    void NoRewardItem();
    
    Slider _CompletePuzzleSlider { get; set; }

}
