using UnityEngine;

public interface IPuzzle
{
    bool CompleteFlag { get; }
    
    IItem RewardItem { get; }
    Player _player { get; set; }
    void NoRewardItem();

}
