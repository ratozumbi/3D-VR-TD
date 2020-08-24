using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTarget : Cube
{
    // Start is called before the first frame update
    void Start()
    {
        //TODO get object instead of only one script?
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<CubeGrid>();
        type = CubeType.end;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        print("collide");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
