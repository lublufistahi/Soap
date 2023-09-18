using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiewDirection : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    public Transform aimTarget;
    public Selectable CurrentSelectable;
    public Camera cam;

    void LateUpdate()
    {
       HeadMovement();      
    }

    void HeadMovement()
    {
        Ray headmovementray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(headmovementray, out hit, Mathf.Infinity, layerMask))
        {
            
            aimTarget.position = hit.point;
            float dist = Vector3.Distance(hit.point, transform.position);
            
            if(dist <10)
            {
                Selectable selectable = hit.collider.gameObject.GetComponent<Selectable>();
                if(selectable)
                {
                if(CurrentSelectable && CurrentSelectable != selectable)
                {
                    CurrentSelectable.Deselect();
                }
                CurrentSelectable = selectable;
                selectable.Select();
                //Debug.Log("Получилось");
                }
                else
                {
                if(CurrentSelectable)
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
                }
            }
            else
            {
                if(CurrentSelectable)
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
            }


        }
        else
        {   
            if(CurrentSelectable)
                {
                    CurrentSelectable.Deselect();
                    CurrentSelectable = null;
                }
        }
        //Debug.DrawRay(transform.position,(aimTarget.position-transform.position),Color.white);
        
    }
}
