using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdditionalInformation : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private Controls myControls;
    private InputAction jumpAction;
    private InputActionMap playerNormal;
    private void Awake()
    {
        myControls = new Controls();
    }
    private void OnEnable()
    {
        playerNormal = actionAsset.FindActionMap("PlayerNormal");
        jumpAction = playerNormal.FindAction("Jump");
        actionAsset.Enable();
    }
    private void OnDisable()
    {
        actionAsset.Disable();
    }

    private void Update()
    {
        #region Inspector approach >> Aditional approach
        /* if (jumpAction.WasPressedThisFrame())
         {
             Debug.Log("Was pressed this frame");
         }

         if(jumpAction.WasPerformedThisFrame())
         {
             Debug.Log("Was performed this frame");
         }

         if (jumpAction.WasReleasedThisFrame())
         {
             Debug.Log("Was released this frame");
         }

         if (jumpAction.IsPressed())
         {
             Debug.Log("Is pressed");
         }*/
        #endregion


        #region C# Class Generated approach >> Aditional approach

        if (myControls.PlayerNormal.Jump.WasPressedThisFrame())
        {
            Debug.Log("Was pressed this frame");
        }
        if (myControls.PlayerNormal.Jump.WasPerformedThisFrame())
        {
            Debug.Log("Was performed this frame");
        }
        if (myControls.PlayerNormal.Jump.WasReleasedThisFrame())
        {
            Debug.Log("Was released this frame");
        }
        if (myControls.PlayerNormal.Jump.IsPressed())
        {
            Debug.Log("Is pressed");
        }

        #endregion

    }

}
