using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.;

public class TowerShoot : MonoBehaviour
{

    public float shootRate = 1f;
    public float damage = 1f;

    public LayerMask hitMask;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        hitMask = LayerMask.GetMask("Enemy");
    }

    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, hitMask))
        {
            hit.transform.gameObject.GetComponent<Enemy>().GetHit();
        }

    }

    public void OnCollisionStay(Collision collision)
    {
        if (target == null)
        {
            target = collision.gameObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {

            transform.parent.transform.LookAt(target.transform.position, new Vector3(1, 0, 0));
        }
    }
}

