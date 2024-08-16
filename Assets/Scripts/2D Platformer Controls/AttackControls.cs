using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{

    [SerializeField] private GatherInput gInput;
    private Animator animator;
    private Player player;
    public bool attackStarted;
    [SerializeField] private PlayerControls playerControls;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }


    void Update()
    {
        if (player.AtInventory) return;

        if (gInput.tryToAttack)
        {
            if (!attackStarted)
            {
                attackStarted = true;
                animator.SetBool("Attack", attackStarted);
            }
            gInput.tryToAttack = false;
        }

        if (gInput.trySpecialAttack)
        {
            if(attackStarted == false && playerControls.isGrounded)
            {
                attackStarted = true;
                animator.Play("Attack_Special");
            }
            gInput.trySpecialAttack = false;
        }
    }

    public void ResetAttack()
    {
        attackStarted = false;
        //disable the attack collider
        //Call this if you die
        animator.SetBool("Attack", attackStarted);
    }

    public void ResetSpecialAttack()
    {
        attackStarted = false;
       
    }

}
