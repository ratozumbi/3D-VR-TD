using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBall : MonoBehaviour
{
    public GameGrid cubeGrid;
    public float moveSpeed = 2.0f;
    public Vector3 moveTo;


    public List<Vector3> path;

    private int currPath = 0;

    public int life = 30;

    public enum BallType
    {
        head,
        body,
        food
    }

    private BallType type;
    private Vector3 whatIsFoward = Vector3.forward;//todo:check

    public void SetTypeFood()
    {
        type = BallType.food;
    }
    
    
    
    void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();

        if (type == BallType.head)
        {
            path.Add(whatIsFoward);
        }
        
        UpdatePath();
        foreach (var objCube in cubeGrid.grid)
        {
            objCube.GetComponent<Cube>()?.CubeChanged.AddListener(UpdatePath);
        }
    }

    public void Update()
    {

        if (type == BallType.head)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, path[currPath], moveSpeed * Time.deltaTime);
            if (Vector3.Distance(path[currPath], transform.localPosition) < 0.0001f)
            {
                if (type == BallType.head)
                {
                    path.Add(whatIsFoward);
                }
                
            }
        }
        

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
    
    public void GetHit(int damge)
    {
        life = life - damge;
        print("Got hit!");
    }

    void UpdatePath()
    {

        currPath = 0;

        path = transform.parent.GetComponent<BasicBall>().path;

    }

}
