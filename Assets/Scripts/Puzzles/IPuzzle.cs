using UnityEngine;

public interface IPuzzle
{
    bool CompleteFlag { get; }
    
    IItem RewardItem { get; }
    GameObject Player { get; }

    void NoRewardItem();

}
