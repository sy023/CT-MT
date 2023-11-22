using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Call from Files
    public InputHandler inputHandler { get; private set; }
    public PlayerLocomotion playerLocomotion { get; private set; }
    public static PlayerController playerController { get; private set; }
    #endregion
    private void Awake()
    {
        playerController = PlayerController.playerController;
        inputHandler = GetComponent<InputHandler>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    void Start()
    {
        inputHandler ??= GetComponent<InputHandler>();
        playerLocomotion ??= GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputHandler.inputUpdate();
        playerLocomotion.HandlesAllMovement();
    }
}
