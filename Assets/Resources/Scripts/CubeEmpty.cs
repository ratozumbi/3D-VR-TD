using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEmpty : Cube
{
    private bool shouldSelfDestroy = false;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        type = CubeType.empty;
        //cubeGrid = GameObject.FindGameObjectWithTag("Grid").GetComponent<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Activate()
    {
        var go = Instantiate(Resources.Load<GameObject>("Prefabs/CubeBlock"), transform.position, transform.rotation, transform.parent);
        cubeGrid.grid[Util.toInt(transform.localPosition.x), Util.toInt(transform.localPosition.y), Util.toInt(transform.localPosition.z)] = go;
        shouldSelfDestroy = true;
        OnCubeChanged();
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

    protected override void OnCubeChanged()
    {
        base.OnCubeChanged();
    }

}
