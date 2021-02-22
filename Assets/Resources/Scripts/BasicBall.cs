using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Composites;

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
    private Vector3 whatIsFoward = Vector3.forward;
    private Vector3 bufferWhatIsFoward = Vector3.forward;

    [HideInInspector] public Action<Vector3> Reached;

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

        Reached += vector3 =>
        {
            whatIsFoward = bufferWhatIsFoward;
        };
    }
    
    public void OnMoveUp(InputValue input)
    {
        Debug.Log("move up");
        bufferWhatIsFoward = Vector3.up;
    }
    public void OnMoveDown(InputValue input)
    {
        Debug.Log("move down");
        bufferWhatIsFoward = Vector3.down;
    }
    public void OnMoveLeft(InputValue input)
    {
        Debug.Log("move left");
        bufferWhatIsFoward = Vector3.left;
    }
    public void OnMoveRight(InputValue input)
    {
        Debug.Log("move right");
        bufferWhatIsFoward = Vector3.right;
    }
    
    public void OnMove(InputValue input)
    {
        Debug.Log("move "+ vec2.x + " "+vec2.y );
        var vec2 = input.Get<Vector2>();

        bufferWhatIsFoward = new Vector3(vec2.x,0,vec2.y).normalized;
    }


    #region FSM
    public void SetTypeFood()
    {
        type = BallType.food;
    }

    #endregion

    public void Update()
    {

        if (type == BallType.head)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, whatIsFoward + Util.ToGridPosition(gameObject), moveSpeed * Time.deltaTime);
            if (Vector3.Distance(path[currPath], transform.localPosition) < 0.0001f)
            {
                path.Add(whatIsFoward);
                Reached?.Invoke(whatIsFoward);
            }
        }
        
        if (type == BallType.body)
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

        //path = transform.parent.GetComponent<BasicBall>().path;

    }

}
