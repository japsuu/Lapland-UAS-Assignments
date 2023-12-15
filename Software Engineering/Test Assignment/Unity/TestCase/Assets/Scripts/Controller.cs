using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private CharacterMoveBehaviour characterMoveBehaviour;


    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime;

        characterMoveBehaviour.Move(new Vector3(horizontal, 0, vertical));

    }
}
