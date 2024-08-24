using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    #region Inspector Reference Approach
    //public InputActionAsset actionAsset;

    //private InputActionMap playerNormal;
    //private InputAction jumpAction;
    //private InputAction moveAction;
    //private InputAction attackAction;
    #endregion

    // private Controls myControls; >C sharp generated approach<

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject canvasRebindGO;
    private InputActionMap playerNormalActionMap;
    private InputAction move;
    private InputAction moveVertical;
    private InputAction jump;
    private InputAction attack;
    private InputAction specialAttack;
    private InputAction canvasToggle;

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;
    public bool trySpecialAttack;


    private void Awake()
    {
        //myControls = new Controls(); >C sharp generated approach<
        #region Inspector Reference Approach
        //playerNormal = actionAsset.FindActionMap("PlayerNormal");
        //jumpAction = playerNormal.FindAction("Jump");
        //moveAction = playerNormal.FindAction("MoveHorizontal");
        //attackAction = playerNormal.FindAction("Attack");
        #endregion
    }

    private void OnEnable()
    {
        #region Player Input Workflow

        playerNormalActionMap = playerInput.actions.FindActionMap("PlayerNormal");
        move = playerInput.actions["MoveHorizontal"];
        moveVertical = playerInput.actions["MoveVertical"];
        jump = playerInput.actions["Jump"];
        attack = playerInput.actions["Attack"];
        specialAttack = playerInput.actions["SpecialAttack"];
        canvasToggle = playerInput.actions["CanvasToggle"];

        jump.performed += JumpExample;

        attack.performed += AttackExample;
        attack.canceled += AttackStopExample;

        specialAttack.performed += SpecialExample;
        specialAttack.canceled += StopSpecialExample;

        canvasToggle.performed += CanvasControl;

        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            playerInput.actions.LoadBindingOverridesFromJson(rebinds);

        #endregion

        #region Csharp generated approach
        //myControls.PlayerNormal.Enable();
        //myControls.PlayerNormal.Jump.Enable();
        //myControls.PlayerNormal.Jump.started += JumpStarted;
        /*
          myControls.PlayerNormal.Jump.performed += JumpExample;
          myControls.PlayerNormal.Jump.canceled += JumpStopExample;

          myControls.PlayerNormal.Attack.performed += AttackExample;
          myControls.PlayerNormal.Attack.canceled += AttackStopExample;

          myControls.PlayerNormal.SpecialAttack.performed += SpecialExample;
          myControls.PlayerNormal.SpecialAttack.canceled += StopSpecialExample;

          myControls.Enable();
        */
        #endregion
        #region Inspector Reference Approach
        //jumpAction.performed += JumpExample;
        //jumpAction.canceled += JumpStopExample;

        //attackAction.performed += AttackExample;
        //attackAction.canceled += AttackStopExample;

        //actionAsset.Enable();
        //playerNormal.Enable();
        //jumpAction.Enable();
        #endregion
    }


    private void OnDisable()
    {
        #region Player Input Workflow

        jump.performed -= JumpExample;

        attack.performed -= AttackExample;
        attack.canceled -= AttackStopExample;

        specialAttack.performed -= SpecialExample;
        specialAttack.canceled -= StopSpecialExample;

        canvasToggle.performed -= CanvasControl;

        playerNormalActionMap.Disable();

        #endregion

        #region Csharp generated approach
        //  myControls.PlayerNormal.Jump.started -= JumpStarted;
        /*
        myControls.PlayerNormal.Jump.performed -= JumpExample;
        myControls.PlayerNormal.Jump.canceled -= JumpStopExample;

        myControls.PlayerNormal.Attack.performed -= AttackExample;
        myControls.PlayerNormal.Attack.canceled -= AttackStopExample;

        myControls.PlayerNormal.SpecialAttack.performed -= SpecialExample;
        myControls.PlayerNormal.SpecialAttack.canceled -= StopSpecialExample;

        myControls.Disable();

        */
        #endregion
        #region Inspector Reference Approach
        //jumpAction.performed -= JumpExample;
        //jumpAction.canceled -= JumpStopExample;

        //attackAction.performed -= AttackExample;
        //attackAction.canceled -= AttackStopExample;

        //actionAsset.Disable();
        //jumpAction.Disable();
        #endregion
    }

    void Update()
    {
        // valueX = myControls.PlayerNormal.MoveHorizontal.ReadValue<float>(); >C sharp generated approach<

        valueX = move.ReadValue<float>();

        if (valueX > 0.01f)
        {
            valueX = 1;
        }
        else if (valueX < 0 && valueX >= -1)
        {
            valueX = -1;
        }
        else
        {
            valueX = 0;
        }

    }

    private void CanvasControl(InputAction.CallbackContext value)
    {
        if (canvasRebindGO.activeSelf)
            canvasRebindGO.SetActive(false);
        else
            canvasRebindGO.SetActive(true);
    }

    private void JumpExample(InputAction.CallbackContext value)
    {

        tryToJump = true;
    }
    private void JumpStopExample(InputAction.CallbackContext value)
    {
        tryToJump = false;
    }

    private void AttackExample(InputAction.CallbackContext value)
    {
        tryToAttack = true;
    }
    private void AttackStopExample(InputAction.CallbackContext value)
    {
        tryToAttack = false;
    }

    private void SpecialExample(InputAction.CallbackContext value)
    {
        trySpecialAttack = true;
    }
    private void StopSpecialExample(InputAction.CallbackContext value)
    {
        trySpecialAttack = false;
    }





}
