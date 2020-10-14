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
    public float shootRate = 0.3f;
    public int damage = 1;

    public TowerRadar radar;

    private Animator myAnimator;
    private bool canShoot = true;
    private LineRenderer myLineRenderer;
    private LineRenderer parentLineRenderer;
    private void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
        parentLineRenderer = GetComponentInParent<LineRenderer>();
        myAnimator = GetComponent<Animator>();
    }


    public int Shoot()
    {
        Debug.Log("shoot1" );
        RaycastHit hit;
        Vector3 angle = transform.TransformDirection(Vector3.up);
        Debug.DrawRay(transform.position, angle,Color.magenta,2f);
        if (Physics.Raycast(transform.position, angle, out hit, Mathf.Infinity, radar.hitMask))
        {
            hit.transform.gameObject.GetComponent<Enemy>().GetHit(damage);

            print("shoot2" );
            myAnimator.Play("TowerShoot");
            Vector3 hitpos = new Vector3(
                hit.transform.position.x / transform.localScale.x,
                hit.transform.position.y / transform.localScale.y,
                hit.transform.position.z / transform.localScale.z);
            myLineRenderer.SetPositions(new Vector3[2] { Vector3.zero, hitpos});
        }
        StartCoroutine(Util.TimedEvent(Reload, lazerShowTime));
        return 0;
    }

    public int Reload()
    {
        canShoot = true;
        myLineRenderer.SetPositions(new Vector3[2] { Vector3.zero, Vector3.zero});
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && radar.target != null)
        {
            canShoot = false;
            StartCoroutine(Util.TimedEvent(Shoot, shootRate));
        }
        
        if (radar.target != null)
        {
            transform.parent.transform.LookAt(radar.target.transform);
            transform.parent.eulerAngles += new Vector3(90, 0, 0);
        }
    }
}

