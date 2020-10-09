using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.;

public class TowerShoot : MonoBehaviour
{
    public float lazerShowTime = 0.3f;
    public float shootRate = 0.6f;
    public int damage = 1;

    public TowerRadar radar;

    private Animator myAnimator;
    private bool canShoot = true;
    private LineRenderer lineRenderer;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }


    public int Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, radar.hitMask))
        {
            print("shoot ray " + hit.transform.gameObject.name);
            hit.transform.gameObject.GetComponent<Enemy>().GetHit(damage);

            myAnimator.Play("TowerShoot");

            GetComponentInParent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position});
            // GetComponent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position});
        }
        StartCoroutine(Util.TimedEvent(Reload, lazerShowTime));
        return 0;
    }

    public int Reload()
    {
        canShoot = true;
        GetComponentInParent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, Vector3.zero});
        // GetComponent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, Vector3.zero});
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            StartCoroutine(Util.TimedEvent(Shoot, shootRate));
        }
        
        if (radar.target != null)
        {
            transform.parent.transform.LookAt(radar.target.transform);
            transform.parent.localEulerAngles += new Vector3(90, 0, 0);
        }
    }
}

