using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.;

public class TowerShoot : MonoBehaviour
{

    public float shootRate = 0.6f;
    public float damage = 1f;

    public TowerRadar radar;

    private bool canShoot = true;


    public int Shoot()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit, Mathf.Infinity, radar.hitMask))
        {
            print("shoot ray " + hit.transform.gameObject.name);
            hit.transform.gameObject.GetComponent<Enemy>().GetHit();
            var lineR = gameObject.GetComponentInParent<LineRenderer>();

            lineR.SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position});
            GetComponent<LineRenderer>().SetPositions(new Vector3[2] { Vector3.zero, hit.transform.position});
        }
        return 0;
    }

    // Update is called once per frame
    void Update()
    {
        // targetTime -= Time.deltaTime;

        //if (targetTime <= 0.0f)
        //{
        //    timerEnded();
        //}
        //if (Input.GetKey(KeyCode.Return))
        //{

        //}
        if (canShoot)
        {
            StartCoroutine(TimedEvent(Shoot, shootRate));
        }
        
        if (radar.target != null)
        {

            transform.parent.transform.LookAt(radar.target.transform);
            transform.parent.localEulerAngles += new Vector3(90, 0, 0);
        }
    }

    IEnumerator TimedEvent(Func<int> evt,float time)
    {
        canShoot = false;
        evt();
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}

