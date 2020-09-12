using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameGrid cubeGrid;
    public float moveSpeed = 2.0f;
    public Vector3 moveTo;


    public List<Vector3> path;

    private int currPath = 0;

    public int life = 30;

    void Start()
    {
        //cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
        //UpdatePath();
        //foreach (var objCube in cubeGrid.grid)
        //{
        //    objCube.GetComponent<Cube>().CubeChanged.AddListener(UpdatePath);
        //}
    }

    public void Update()
    {

        //transform.localPosition = Vector3.MoveTowards(transform.localPosition, path[currPath], moveSpeed * Time.deltaTime);
        //if (Vector3.Distance(path[currPath], transform.localPosition) < 0.01f)
        //{
        //    currPath++;
        //}


        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetHit()
    {
        life--;
        print("Got hit!");
    }

    void UpdatePath()
    {

        currPath = 0;
        path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, Util.ToGridPosition(gameObject), moveTo, cubeGrid.checkCubeBlocking);

    }

}
