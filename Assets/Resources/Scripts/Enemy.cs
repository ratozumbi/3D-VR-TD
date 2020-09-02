using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameGrid cubeGrid;
    public Vector3 target;
    public List<Vector3> path;
    public Vector3 gridPosition = Vector3.zero;

    public float speed = 2.0f;

    private int currPath = 0;

    void Start()
    {
        UpdatePath();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdatePath();
        }

        transform.localPosition = Vector3.MoveTowards(transform.position, path[currPath], speed* Time.deltaTime);
        if(Vector3.Distance(path[currPath], transform.position)<0.01f)
        {
            currPath++;
        }

        gridPosition = Util.ToGridPosition(gameObject);

    }

    void UpdatePath()
    {
        currPath = 0;
        var path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, gridPosition, target, cubeGrid.checkBlockBlocking);
        GetComponent<LineRenderer>().positionCount = path.Count;
        GetComponent<LineRenderer>().SetPositions(path.ToArray());

    }

}
