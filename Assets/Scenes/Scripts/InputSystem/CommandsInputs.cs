using System;
using UnityEngine;
using UnityEngine.InputSystem;
using BrainlessPet.Scriptables;
namespace BrainlessPet.Inputs
{
    public class CommandsInputs : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO jumpTrigger;
        [SerializeField] private VoidEventChannelSO speedUpTrigger;
        [SerializeField] private VoidEventChannelSO slowDownTrigger;
        [SerializeField] private VoidEventChannelSO stopTrigger;
        [SerializeField] private VoidEventChannelSO turnTrigger;
        [SerializeField] private VoidEventChannelSO useItemTrigger;
        private GameInputs generalInputs;
        private void Awake() 
        {
            generalInputs = new GameInputs();
        }

        private void OnEnable() 
        {
            generalInputs.Commands.Enable();
            generalInputs.Commands.Jump.performed += OnJumpTrigger;
            generalInputs.Commands.Jump.canceled += OnJumpTrigger;
            generalInputs.Commands.SlowDown.performed += OnSlowDownTrigger;
            generalInputs.Commands.SpeedUp.performed += OnSpeedUpTrigger;
            generalInputs.Commands.Stop.performed += OnStopTrigger;
            generalInputs.Commands.Turn.performed += OnTurnTrigger;
            generalInputs.Commands.UseItems.performed += OnUseItemTrigger;
        }

        private void OnDisable() 
        {
            generalInputs.Commands.Enable();
            generalInputs.Commands.Jump.performed -= OnJumpTrigger;
            generalInputs.Commands.Jump.canceled -= OnJumpTrigger;
            generalInputs.Commands.SlowDown.performed -= OnSlowDownTrigger;
            generalInputs.Commands.SpeedUp.performed -= OnSpeedUpTrigger;
            generalInputs.Commands.Stop.performed -= OnStopTrigger;
            generalInputs.Commands.Turn.performed -= OnTurnTrigger;
            generalInputs.Commands.UseItems.performed -= OnUseItemTrigger;
        }

        private void OnJumpTrigger(InputAction.CallbackContext obj){
            Debug.Log(obj);
            jumpTrigger.RaiseEvent();
            
        }
        private void OnSpeedUpTrigger(InputAction.CallbackContext obj){
            Debug.Log($"obj {obj}");
            speedUpTrigger.RaiseEvent();
            
        } 
        //private void OnSpeedUpTrigger(InputAction.CallbackContext obj) => speedUpTrigger.RaiseEvent();
        private void OnSlowDownTrigger(InputAction.CallbackContext obj) => slowDownTrigger.RaiseEvent();
        private void OnStopTrigger(InputAction.CallbackContext obj) => stopTrigger.RaiseEvent();
        private void OnTurnTrigger(InputAction.CallbackContext obj) => turnTrigger.RaiseEvent();
        private void OnUseItemTrigger(InputAction.CallbackContext obj) => useItemTrigger.RaiseEvent();
    }
}

