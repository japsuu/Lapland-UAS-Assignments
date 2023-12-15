using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoveBehaviour : MonoBehaviour
{

    private CharacterController characterController;

    [SerializeField]
    private bool useGravity = false;


    private Vector3 playerVelocity = Vector3.zero;
    private float speed = 0;

    public bool UseGravity {
        get
        {
            return this.useGravity;
        }
        set
        {
            this.useGravity = value;
        }
    }

    void Awake()
    {
        if ((characterController = GetComponent<CharacterController>()) == null)
        {
            Debug.LogError("CharacterMoveBehaviour - Awake() -> Cannot Find CharacterController");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.useGravity)
            playerVelocity += new Vector3(0, DefaultValues.gravity * Time.deltaTime, 0);


        characterController.Move(playerVelocity * Time.deltaTime);

    }


    public void Move(Vector3 moveVector)
    {
        characterController.Move(moveVector);

    }

}
