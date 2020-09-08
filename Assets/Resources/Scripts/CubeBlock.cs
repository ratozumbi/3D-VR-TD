using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBlock : Cube
{
    
    // Start is called before the first frame update
    void Start()
    {
        type = CubeType.block;
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
