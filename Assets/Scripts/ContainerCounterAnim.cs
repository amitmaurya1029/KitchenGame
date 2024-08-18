using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnim : MonoBehaviour
{
    [SerializeField] private ContainerCounter containerCounter;
    private Animator animator;
    private const String OPEN_CLOSE = "OpenClose";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnContainerCounterInteraction += PlayContainerCounterAnim;
    }

    private void PlayContainerCounterAnim(object sender, EventArgs e)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }

    
}
