
using UnityEngine;

public class CubeGrid : MonoBehaviour
{
    public GameObject cubeEmpty;
    public GameObject cubeStart;
    public GameObject cubeTarget;
    public GameObject cubeBlock;
    public GameObject textObj;

    public int size = 8;

    internal GameObject[,,] grid;
    internal GameObject[,,] textGrid;
    internal Vector3 start;
    internal Vector3 target;

    internal Vector3[,,] gridVec3;

    private void OnEnable()
    {
        if (size % 2 != 0) size++;
        grid = new GameObject[size, size, size];
        textGrid = new GameObject[size, size, size];
        gridVec3 = new Vector3[size, size, size];
    }

    void Start()
    {
        cubeStart.GetComponent<CubeStart>().cubeGrid = this;


        do
        {
            start.x = Random.Range(0, size);
            start.y = Random.Range(0, size);
            start.z = Random.Range(0, size);

            target.x = Random.Range(0, size);
            target.y = Random.Range(0, size);
            target.z = Random.Range(0, size);
        } while (Vector3.Distance(start, target) < (size));

        
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size ; y++)
            {
                for (int z = 0; z < size; z++)
                {
                    GameObject goCube = null;
                    var willBlock = Random.value < 0.1f ? true : false;

                    if (Util.vec3eq(new Vector3(x, y, z), start))
                    {
                        goCube = grid[x, y, z] = Instantiate(cubeStart, start, Quaternion.identity, transform);
                        goCube.GetComponent<CubeStart>().target = target;
                    }
                    else if (Util.vec3eq(new Vector3(x, y, z), target))
                    {
                        goCube = grid[x, y, z] = Instantiate(cubeTarget, target, Quaternion.identity, transform);
                    }
                    else
                    {
                        if (willBlock)
                        {
                            goCube = grid[x, y, z] = Instantiate(cubeBlock, new Vector3(x, y, z), Quaternion.identity, transform);
                        }
                        else
                        {
                            goCube = grid[x, y, z] = Instantiate(cubeEmpty, new Vector3(x, y, z), Quaternion.identity, transform);
                        }
                        
                    }

                    //textGrid[x, y, z] = Instantiate(textObj, new Vector3(x, y, z), Quaternion.identity, transform);
                    gridVec3[x, y, z] = goCube.transform.position;
                }
            }
        }
    }

    public override string ToString()
    {
        for (int i = grid.GetLowerBound(0); i <= grid.GetUpperBound(0); i++)
        {
            for (int j = grid.GetLowerBound(1); j <= grid.GetUpperBound(1); j++)
            {
                for (int k = grid.GetLowerBound(2); k <= grid.GetUpperBound(2); k++)
                {
                    return string.Format("{0},{1},{2}: {3}", i, j, k, grid[i, j, k].name);
                }
            }
        }

        return "";  
    }
    public bool checkBlockBlocking(Vector3 toCheck)
    {
        var check = grid[Util.toInt(toCheck.x), Util.toInt(toCheck.y), Util.toInt(toCheck.z)];
        if (check.GetComponent<Cube>().type == Cube.CubeType.block)
            return true;
        else
            return false;
    }
}
