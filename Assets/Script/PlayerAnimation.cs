using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private InputHandler inputManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputHandler>();
    }

    void Update()
    {
        animator.SetFloat("Speed", inputManager.vectorFunc.magnitude, 0.05f, Time.deltaTime);
    }
}
