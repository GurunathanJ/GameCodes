using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //reference of player controller
    private CharacterController characterController;
    private Animator animator;
    [SerializeField]
    private float fowardSpeed=10f;
    [SerializeField]
    private float backwardSpeed=5f;
    [SerializeField]
    private float turnSpeed=7f;
    [SerializeField]
    private float turnSpeed1=10f;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

        Cursor.lockState=CursorLockMode.Locked;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var M_horizontal = Input.GetAxis("Mouse X");

        var movement = new Vector3(horizontal, 0, vertical);

        // characterController.SimpleMove(movement*Time.deltaTime*speed);
        
         animator.SetFloat("Speed",vertical);
         transform.Rotate(Vector3.up,horizontal*turnSpeed*Time.deltaTime);
         transform.Rotate(Vector3.up,M_horizontal*turnSpeed1*Time.deltaTime);
         if(vertical!=0)
         {
            float motionSpeed = (vertical>0)? fowardSpeed : backwardSpeed;
            characterController.SimpleMove(transform.forward*motionSpeed*vertical);
         }
        // if(movement.magnitude>0)
        // {
        // Quaternion newDirection = Quaternion.LookRotation(movement);
        // transform.rotation = Quaternion.Slerp(transform.rotation,newDirection,Time.deltaTime*turnSpeed);
        // }


    }
}
