using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private Player player;
    private const string IS_WALKING = "IsWalking";

    void Update()
    {
        if(player.IsPlayerWalking())
        {
            PlayWalkAnimation();
        }
        else
        {
           StopWalkAnimation();
        }
    }

    private void PlayWalkAnimation()
    {
        animator.SetBool(IS_WALKING, true);
    }

    private void StopWalkAnimation()
    {
        animator.SetBool(IS_WALKING, false);
    }
}
