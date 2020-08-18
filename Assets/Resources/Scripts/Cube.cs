using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Cube : MonoBehaviour
{
    public Grid cubeGrid;

    private void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
    }

    
}
