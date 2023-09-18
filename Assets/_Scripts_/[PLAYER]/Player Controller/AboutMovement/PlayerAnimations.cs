using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Movement _movement;
    private Animator _animation;

    void Start()
    {
        _animation = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        LocomotionAnimations();
        AimAnimations();
    }
    void LocomotionAnimations()
    {
        float VerticalMovement = Input.GetAxis("Vertical");
        _animation.SetFloat("MovementY",VerticalMovement);
        float HorizontalMovement = Input.GetAxis("Horizontal");
        _animation.SetFloat("MovementX",HorizontalMovement);
    }
    void AimAnimations()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _animation.SetFloat("Aimming",1);
        }
        else
        {
            _animation.SetFloat("Aimming",0);
        }
    }


}
