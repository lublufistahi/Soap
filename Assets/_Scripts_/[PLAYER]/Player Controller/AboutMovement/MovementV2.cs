using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementV2 : MonoBehaviour
{
    public float moveSpeed = 3;
    public float sprintSpeed = 10;
    [HideInInspector] public Vector3 dir;
    float hzInput, yInput;
    CharacterController controller;
    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;
    [SerializeField] float gravity = -9.81f;
    Vector3 velicity;
    public Camera _mainCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetDirectionAndMove();
        Gravity();
        //Sprint();
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        dir = transform.forward * yInput + transform.right * hzInput;

        controller.Move(dir * moveSpeed * Time.deltaTime);
        Debug.Log(dir);
        Aiming();
    }
    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x,transform.position.y - groundYOffset,transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f,groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) velicity.y += gravity * Time.deltaTime;
        else if (velicity.y < 0) velicity.y = -2;

        controller.Move(velicity * Time.deltaTime);
    }

    void Aiming()
    {
        if (yInput != 0 || hzInput != 0) transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
    }   

    void Sprint()
    {
        if(Input.GetButton("Sprint"))
        {
            if (Input.GetButtonDown("Sprint")) 
            {
                transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
                Vector3 rotatonpos = new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z);
                Debug.Log(rotatonpos);
            }
            hzInput = Input.GetAxis("Horizontal");
            yInput = Input.GetAxis("Vertical");
            

            

            //transform.rotation = Quaternion.SetFromToRotation(transform.forward, transform.right * hzInput);
            //transform.Rotate(0,hzInput * 90 + yInput *180, 0);
            //controller.Move(transform.forward * yInput * sprintSpeed * Time.deltaTime);
            //Quaternion targetv = Quaternion.Euler(0,transform.rotation.y - yInput * 90, 0); // умножаем на 90 так как поворот на 90 градусов а vf передаёт расположение стика значениями от -1 до 1.
            //Quaternion targetx = Quaternion.Euler(0,transform.rotation.y - hzInput * 90, 0); // тоже самое что и выше

            //transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetv, Time.time * 60); // поворот
       
            //transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, targetx, Time.time * 60);
            

        }

    }
}
