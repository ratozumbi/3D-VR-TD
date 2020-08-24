using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Cube : MonoBehaviour
{
    public CubeGrid cubeGrid;

    public enum CubeType
    {
        empty,
        start,
        end,
        block
    }
    public CubeType type;

    private void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<CubeGrid>();
    }
    
}
