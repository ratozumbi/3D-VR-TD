using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameGrid cubeGrid;
    public Vector3 cubeEnd_Position;
    public List<Vector3> path;
    public Vector3 gridPosition = Vector3.zero;

    public float speed = 2.0f;

    private int currPath = 0;

    void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
        UpdatePath();
        foreach(var objCube in cubeGrid.grid)
        {
            objCube.GetComponent<Cube>().OnCubeChanged += UpdatePath;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdatePath();
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition, path[currPath], speed * Time.deltaTime);
        if (Vector3.Distance(path[currPath], transform.localPosition)<0.01f)
        {
            currPath++;
        }

        gridPosition = Util.ToGridPosition(gameObject);

    }

    void UpdatePath()
    {

        currPath = 0;
        var path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, gridPosition, cubeEnd_Position, cubeGrid.checkCubeBlocking);
        GetComponent<LineRenderer>().positionCount = path.Count;
        GetComponent<LineRenderer>().SetPositions(path.ToArray());

    }

}
