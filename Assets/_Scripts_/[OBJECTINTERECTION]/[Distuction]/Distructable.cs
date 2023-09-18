using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distructable : MonoBehaviour
{
    public GameObject destroyVersion;
    private bool colisionFact;

    void Update() 
    {
        DestroyObj();
    }
    public void DestroyObj()
    {
        if(colisionFact == true)
        {
            Instantiate(destroyVersion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        ColisionCheacker(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        ColisionCheacker(collision, false);
    }

    private void ColisionCheacker(Collision collision,bool value)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            colisionFact = value;
        }
    }
}
