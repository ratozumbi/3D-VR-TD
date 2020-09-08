using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStart : Cube
{
    public LineRenderer gridLineRenderer;
    public List<Vector3> path = new List<Vector3>();
    public Vector3 cubeEnd_Position;
    void Start()
    {
        cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
        gridLineRenderer = cubeGrid.GetComponent<LineRenderer>();
        type = CubeType.start;
        OnCubeChanged += UpdatePath;
        UpdatePath();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            UpdatePath();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var go = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), transform.position, transform.rotation , transform.parent);
            go.GetComponent<Enemy>().cubeGrid = cubeGrid;
            go.GetComponent<Enemy>().path = path;
            go.GetComponent<Enemy>().cubeEnd_Position = cubeEnd_Position;
        }
    }

    void UpdatePath()
    {
        path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, Util.ToGridPosition(gameObject), cubeEnd_Position, cubeGrid.checkCubeBlocking);
        gridLineRenderer.positionCount = path.Count;
        gridLineRenderer.SetPositions(path.ToArray());
    }
}
