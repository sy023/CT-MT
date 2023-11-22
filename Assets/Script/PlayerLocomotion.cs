using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerController playerController;
    private CharacterController cController;
    
    private Vector3 vectorMovement;
    public float moveSpeed = 10;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        cController = GetComponent<CharacterController>();
    }

    public void HandlesAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        #region Camera Transform
        var forward = UnityEngine.Camera.main.transform.forward;
        var right = UnityEngine.Camera.main.transform.right;
        forward.y = right.y = 0;
        #endregion

        vectorMovement = (forward * playerController.inputHandler.vectorFunc.y + right * playerController.inputHandler.vectorFunc.x) * moveSpeed;
                vectorMovement.y += Physics.gravity.y;
        cController.Move(Time.deltaTime * vectorMovement);

    }
    void HandleRotation()
    {
        var rotationVector = vectorMovement;
        rotationVector.y = 0;

        if (rotationVector.magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotationVector), 10 * Time.deltaTime);
    }
}
