using System;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
    public static bool vec3eq(Vector3 left, Vector3 right)
    {
        return (left.x == right.x &&
            left.y == right.y &&
            left.z == right.z);
    }

    /// <summary>
    /// Funtion used in update 
    /// </summary>
    /// <param name="go">The game object to get the grid position </param>
    /// <returns>Vector3 as grid position</returns>
    /// TODO: Check out of bounds
    /// TODO: IntVector3
    public static Vector3 ToGridPosition(GameObject go)
    {
        return new Vector3(Util.toInt(go.transform.localPosition.x), Util.toInt(go.transform.localPosition.y), Util.toInt(go.transform.localPosition.z));
    }
    public static GameObject ObjFromGrid(GameObject[,,] mat, Vector3 pos)
    {
        return mat[Util.toInt(pos.x), Util.toInt(pos.y), Util.toInt(pos.z)];
    }

    public static Tuple<int, int, int> CoordinatesOf<T>( T value,  T[,,] inMatrix)
    {
        int xx = inMatrix.GetLength(0); // width
        int yy = inMatrix.GetLength(1); // height
        int zz = inMatrix.GetLength(2); // depth

        for (int x = 0; x < xx; ++x)
        {
            for (int y = 0; y < yy; ++y)
            {
                for (int z = 0; z < zz; ++z)
                {
                    if (inMatrix[x, y, z].Equals(value))
                        return Tuple.Create(x, y, z);
                }
            }
        }

        return Tuple.Create(-1, -1, -1);
    }

    //based on https://www.youtube.com/watch?v=KiCBXu4P-2Y
    /// <summary>
    /// Finds a ptah in a 3D matrix. Quadratic matrix only
    /// </summary>
    /// <param name="inMatrix"> The matrix where start and end resides</param>
    /// <param name="dimensionSize">The lateral size of the matrix</param>
    /// <param name="start">The start node</param>
    /// <param name="end">The end node</param>
    /// <returns>A Vector3 list of points in path from start to end</returns>
    /// TODO: break into grid construction and pathfinding
    public static List<Vector3> FindPath(Vector3[,,] inMatrix, int dimensionSize, Vector3 start, Vector3 end, Func<Vector3, bool> specialCheck)
    {

        //queue points
        Queue<float> xq, yq, zq;
        xq = new Queue<float>();
        yq = new Queue<float>();
        zq = new Queue<float>();


        int move_count = 0;

        int nodes_left_in_layer = 1;
        int nodes_left_in_next_layer = 0;

        bool reached_end = false;
        bool[,,] visited = new bool[dimensionSize, dimensionSize, dimensionSize];

        //resulting path
        Vector3[,,] prev = new Vector3[dimensionSize, dimensionSize, dimensionSize];

        //directions to be explored
        int[] dx = { -1, +1, 0, 0, 0, 0 };
        int[] dy = { 0, 0, -1, +1, 0, 0 };
        int[] dz = { 0, 0, 0, 0, -1, +1 };

        visited[toInt(start.x), toInt(start.y), toInt(start.z)] = true;

        xq.Enqueue(start.x);
        yq.Enqueue(start.y);
        zq.Enqueue(start.z);
        
        prev[Util.toInt(start.x), Util.toInt(start.y), Util.toInt(start.z)] = new Vector3(start.x,start.y, start.z);

        while (xq.Count > 0)
        {
            float x = xq.Dequeue();
            float y = yq.Dequeue();
            float z = zq.Dequeue();

            if (Util.vec3eq(inMatrix[Util.toInt(x), Util.toInt(y), Util.toInt(z)], end))
            {
                reached_end = true;
                break;
            }

            //explore(Util.toInt(x), Util.toInt(y), Util.toInt(z));
            for (int i = 0; i < dx.Length; i++)
            {
                int xx = Util.toInt(x + dx[i]);
                int yy = Util.toInt(y + dy[i]);
                int zz = Util.toInt(z + dz[i]);

                if (xx < 0 || yy < 0 || zz < 0) continue;
                if (yy >= dimensionSize || xx >= dimensionSize || zz >= dimensionSize) continue;
                if (visited[xx, yy, zz]) continue;
                if (specialCheck(new Vector3(xx,yy,zz))) continue;

                xq.Enqueue(xx);
                yq.Enqueue(yy);
                zq.Enqueue(zz);

                visited[xx, yy, zz] = true;
                nodes_left_in_next_layer++;
                prev[xx, yy, zz] = new Vector3(x, y, z);
            }

            nodes_left_in_layer--;


            if (nodes_left_in_layer == 0)
            {
                nodes_left_in_layer = nodes_left_in_next_layer;
                nodes_left_in_next_layer = 0;
                move_count++;
            }

        }

        //if (reached_end)
        //{
        //    Debug.Log("move count " + move_count);
        //    return move_count;
        //}
        //else
        //{
        //    return -1;
        //}

        List<Vector3> path = new List<Vector3>();
        Vector3 previous = new Vector3(-1,-1,-1);
        for (Vector3 at = end;
            /*!Util.vec3eq(at, start) &&*/ !Util.vec3eq(at, previous);
            at = prev[toInt(at.x), toInt(at.y), toInt(at.z)])
        {
            previous = at;
            path.Add(at);
        }
        //path.Add(start); //TODO: check for disjoint graph
        path.Reverse();

        if (Util.vec3eq(path[0], start))
        {
            return path;
        }
        else
        {
            return null;
        }

        //return reconstruct();
    }

    //prevent float point issues
    public static int toInt(float n)
    {
        return (int)Math.Round(n);
    }
}