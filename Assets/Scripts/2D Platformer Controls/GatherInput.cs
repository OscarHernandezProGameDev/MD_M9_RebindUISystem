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

#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
    private Controls myControls; //C sharp generated approach
#endif

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private GameObject canvasRebindGO;
#if !BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
    private InputActionMap playerNormalActionMap;
    private InputAction move;
    private InputAction moveVertical;
    private InputAction jump;
    private InputAction attack;
    private InputAction specialAttack;
    private InputAction canvasToggle;
#endif

    public float valueX;
    public bool tryToJump;
    public bool tryToAttack;
    public bool trySpecialAttack;

#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
    public void ActionsResetAndLoad()
    {
        myControls.PlayerNormal.Jump.performed -= JumpExample;
        myControls.PlayerNormal.Jump.canceled -= JumpStopExample;

        myControls.PlayerNormal.Attack.performed -= AttackExample;
        myControls.PlayerNormal.Attack.canceled -= AttackStopExample;

        myControls.PlayerNormal.SpecialAttack.performed -= SpecialExample;
        myControls.PlayerNormal.SpecialAttack.canceled -= StopSpecialExample;

        myControls.PlayerNormal.CanvasToggle.performed -= CanvasControl;

        myControls.Disable();

        myControls = new Controls();

        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            myControls.asset.LoadBindingOverridesFromJson(rebinds);

        myControls.PlayerNormal.Jump.performed += JumpExample;
        myControls.PlayerNormal.Jump.canceled += JumpStopExample;

        myControls.PlayerNormal.Attack.performed += AttackExample;
        myControls.PlayerNormal.Attack.canceled += AttackStopExample;

        myControls.PlayerNormal.SpecialAttack.performed += SpecialExample;
        myControls.PlayerNormal.SpecialAttack.canceled += StopSpecialExample;
        myControls.PlayerNormal.CanvasToggle.performed += CanvasControl;

        myControls.Enable();
    }
#endif


    private void Awake()
    {
#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
        playerInput.enabled = false;
        myControls = new Controls(); //C sharp generated approach
#endif
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

#if !BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
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
#endif

        #endregion

        #region Csharp generated approach
        //myControls.PlayerNormal.Enable();
        //myControls.PlayerNormal.Jump.Enable();
        //myControls.PlayerNormal.Jump.started += JumpStarted;

#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
        var rebinds = PlayerPrefs.GetString("rebinds");
        if (!string.IsNullOrEmpty(rebinds))
            myControls.asset.LoadBindingOverridesFromJson(rebinds);

        myControls.PlayerNormal.Jump.performed += JumpExample;
        myControls.PlayerNormal.Jump.canceled += JumpStopExample;

        myControls.PlayerNormal.Attack.performed += AttackExample;
        myControls.PlayerNormal.Attack.canceled += AttackStopExample;

        myControls.PlayerNormal.SpecialAttack.performed += SpecialExample;
        myControls.PlayerNormal.SpecialAttack.canceled += StopSpecialExample;
        myControls.PlayerNormal.CanvasToggle.performed += CanvasControl;

        myControls.Enable();
#endif
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

#if !BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
        jump.performed -= JumpExample;

        attack.performed -= AttackExample;
        attack.canceled -= AttackStopExample;

        specialAttack.performed -= SpecialExample;
        specialAttack.canceled -= StopSpecialExample;

        canvasToggle.performed -= CanvasControl;

        playerNormalActionMap.Disable();
#endif

        #endregion

        #region Csharp generated approach
        //  myControls.PlayerNormal.Jump.started -= JumpStarted;

#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
        myControls.PlayerNormal.Jump.performed -= JumpExample;
        myControls.PlayerNormal.Jump.canceled -= JumpStopExample;

        myControls.PlayerNormal.Attack.performed -= AttackExample;
        myControls.PlayerNormal.Attack.canceled -= AttackStopExample;

        myControls.PlayerNormal.SpecialAttack.performed -= SpecialExample;
        myControls.PlayerNormal.SpecialAttack.canceled -= StopSpecialExample;

        myControls.PlayerNormal.CanvasToggle.performed -= CanvasControl;

        myControls.Disable();

#endif
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
#if BINDING_PERSISTENTES_CON_CSHARP_CLASS_GENERATED
        valueX = myControls.PlayerNormal.MoveHorizontal.ReadValue<float>(); //C sharp generated approach<
#else
        valueX = move.ReadValue<float>();
#endif

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
