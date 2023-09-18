using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform Target;
    public Vector3 Offset;
    [SerializeField] private float _lerpRate = 10f;
    public float Speed = 10;
    public float mouseSens = 100f;
    float xRotation = 0f;
    // Start is called before the first frame update
    private void OnValidate()
    {
       transform.position = Target.position + Offset;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Speed * Time.deltaTime * _lerpRate);
        CameraRotation();
    }
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-30f,30f);
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }
}
