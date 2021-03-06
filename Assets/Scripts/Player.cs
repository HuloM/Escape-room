﻿using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private IMover _mover;
    private Rotator _rotator;
    private Inventory _inventory;

    public Stats Stats { get; private set; }
    public bool Frozen { get; set; }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = new Mover(this);
        _rotator = new Rotator(this);
        _inventory = GetComponent<Inventory>();
        
        PlayerInput.Instance.MoveModeTogglePressed += MoveModeTogglePressed;
        
        
        Stats = new Stats();
        Stats.Bind(_inventory);
    }

    private void MoveModeTogglePressed()
    {
        if (_mover is NavmeshMover)
            _mover = new Mover(this);
        else
            _mover = new NavmeshMover(this);
    }

    private void Update()
    {
        if (Pause.Active)
            return;

        if (!Frozen)
        {
            _mover.Tick();
            _rotator.Tick();
        }

        if(Input.GetKeyDown(KeyCode.M))
           FindObjectOfType<GameStateMachine>().LevelTwoAccessGranted(true);
    }

}