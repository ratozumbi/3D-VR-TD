using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnd : Cube
{
    // Start is called before the first frame update
    void Start()
    {
        //TODO get object instead of only one script?
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
        type = CubeType.end;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide to target");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
