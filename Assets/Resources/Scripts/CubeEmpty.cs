﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEmpty : Cube
{
    private bool shouldSelfDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        type = CubeType.empty;
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        var go = Instantiate(Resources.Load<GameObject>("Prefabs/CubeBlock"), transform.position, transform.rotation, transform.parent);
        cubeGrid.grid[Util.toInt(transform.position.x), Util.toInt(transform.position.y), Util.toInt(transform.position.z)] = go;
        shouldSelfDestroy = true;
        base.NotifyCubeChanged();
        if (selection != null)
        {
            Destroy(selection);
        }
    }

    public void TestSelfDestroy()
    {
        if(shouldSelfDestroy)
        {
            Destroy(gameObject);
        }
    }
}
