using TMPro;
using UnityEngine;

public interface IPuzzle
{
    bool CompleteFlag { get; }
    
    IItem RewardItem { get; }
    Player _player { get; set; }
    TMP_Text DeselectionText { get; set; }
    void NoRewardItem();

}
