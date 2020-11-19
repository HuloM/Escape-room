using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorNearPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public GameObject player;
    private static readonly int CharacterNearby = Animator.StringToHash("character_nearby");

    private void Update()
    {
        var distance = Vector3.Distance(this.gameObject.transform.position, player.transform.position);
        if (distance < 3)
        {
            _animator.SetBool(CharacterNearby, true);
        }
        else
        {
            _animator.SetBool(CharacterNearby, false);
        }
    }
}
