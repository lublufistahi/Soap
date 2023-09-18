using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float Speed = 5f;

    private bool _isGrounded;
    private Rigidbody _rb;
    public Camera _mainCamera;
    public Transform aimTarget;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MovementLogicWalking();
        Aimming();        
        
    }

    public void MovementLogic2TEST()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        //Debug.Log(movement);

        //if(movement.magnitude > Mathf.Abs(0.05f))
        //{
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(movement),Time.deltaTime * 10);
            //transform.position = transform.position + new Vector3(moveHorizontal * Speed * Time.deltaTime, 0, moveVertical * Speed * Time.deltaTime);    
        //}
        
    } 

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
    private void MovementLogicWalking()
    {
        if (Input.GetAxis("Vertical") >0) //W
        {
            transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * Time.deltaTime * Speed * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Vertical") <0) //S
        {
            transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
            transform.Translate(-Vector3.forward * Time.deltaTime * Speed/2 * -Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") >0) //D
        {
            if(Input.GetAxis("Vertical") != 0)
            {
                if(Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * Speed/2 * Input.GetAxis("Horizontal"));
                    transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
                }
                else
                {
                    transform.Translate(Vector3.right * Time.deltaTime * Speed/4 * Input.GetAxis("Horizontal"));
                    transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
                }
                
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * Speed/2 * Input.GetAxis("Horizontal"));
                transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
            }
        }
        if (Input.GetAxis("Horizontal") <0) //A
        {
            if(Input.GetAxis("Vertical") != 0)
            {
                if(Input.GetAxis("Vertical") > 0)
                {
                    transform.Translate(-Vector3.right * Time.deltaTime * Speed/2 * -Input.GetAxis("Horizontal"));
                    transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
                }
                else
                {
                    transform.Translate(-Vector3.right * Time.deltaTime * Speed/4 * -Input.GetAxis("Horizontal"));
                    transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
                }
            }
            else
            {
                transform.Translate(-Vector3.right * Time.deltaTime * Speed/2 * -Input.GetAxis("Horizontal"));
                transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
            }
        }
    } 

    private void Aimming()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.rotation = Quaternion.Euler(0, _mainCamera.transform.eulerAngles.y, 0);
        }
    }
}