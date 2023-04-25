using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator currentAnimation;

    private void Start()
    {
        currentAnimation = GetComponent<Animator>();
    }

    public void Walking()
    {
        currentAnimation.SetBool("moving", true);
    }

    public void Jumping()
    {
        currentAnimation.SetBool("jumping", true);
    }

    public void Attacking()
    {
        currentAnimation.SetBool("attacking", true);
    }

    public void StopJumping()
    {
        currentAnimation.SetBool("jumping", false);
    }

    public void StopMoving()
    {
        currentAnimation.SetBool("moving", false);
    }

    public void StopAnimations()
    {
        if (currentAnimation.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Debug.Log("Animation over");
        }
    }
}