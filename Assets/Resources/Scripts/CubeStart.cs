using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStart : Cube
{
    public Material pathMaterial;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print("CubeStart start");
            var path = Util.FindPath(cubeGrid.gridVec3, cubeGrid.size, cubeGrid.start, cubeGrid.target);

            for (int i = 1; i < path.Count - 1; i++)
            {
                var nodeObj = cubeGrid.grid[Util.toInt(path[i].x), Util.toInt(path[i].y), Util.toInt(path[i].z)];
                nodeObj.GetComponent<Renderer>().material = pathMaterial;
            }
            print("path draw ok");
        }
    }
}
