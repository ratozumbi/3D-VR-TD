using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.;

public class TowerShoot : MonoBehaviour
{

    public float shootRate = 1f;
    public float damage = 1f;

    public LayerMask hitMask;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        hitMask = LayerMask.GetMask("Enemy");
    }

    public void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, hitMask))
        {
            print("shoot ray");
            hit.transform.gameObject.GetComponent<Enemy>().GetHit();
            var lineR = gameObject.GetComponentInParent<LineRenderer>();

            lineR.SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position });
            GetComponent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position});
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
        if (Input.GetKey(KeyCode.Return))
        {
            Shoot();
        }
        if (target != null)
        {

            transform.parent.transform.LookAt(target.transform);
            transform.parent.localEulerAngles += new Vector3(90, 0, 0);
        }
    }
}

