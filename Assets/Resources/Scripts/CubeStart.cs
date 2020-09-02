using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStart : Cube
{
    public List<Vector3> path = new List<Vector3>();
    public Vector3 cubeEnd_Position;
    void Start()
    {
        type = CubeType.start;
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
            var go = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), transform.localPosition, Quaternion.identity, transform.parent);
            go.GetComponent<Enemy>().cubeGrid = cubeGrid;
            go.GetComponent<Enemy>().path = path;
            go.GetComponent<Enemy>().target = cubeEnd_Position;
        }
    }

    void UpdatePath()
    {
        path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, Util.ToGridPosition(gameObject), cubeEnd_Position, cubeGrid.checkBlockBlocking);
        GetComponent<LineRenderer>().positionCount = path.Count;
        GetComponent<LineRenderer>().SetPositions(path.ToArray());
    }
}
