using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRadar : MonoBehaviour
{
    [HideInInspector] public GameObject target;

    public LayerMask hitMask;

    void Start()
    {
        if(hitMask.value == 0)
            hitMask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        CheckAddTarget(collision);
    }
    private void OnCollisionStay(Collision collision)
    {
        CheckAddTarget(collision);
    }


    private void CheckAddTarget(Collision collision)
    {
        if (target == null)
        {
            if ((1<<collision.gameObject.layer | hitMask.value) == hitMask.value)
            {
                print("set target");
                target = collision.gameObject;
            }
                
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (target != null)
        {
            target = null;
        }
    }

}
