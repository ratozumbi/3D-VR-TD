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
    public static List<Vector3> FindPath(Vector3[,,] inMatrix, int dimensionSize, Vector3 start, Vector3 end)
    {

        //queue points
        List<float> xq, yq, zq;
        xq = new List<float>();
        yq = new List<float>();
        zq = new List<float>();


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

        void explore(int x, int y, int z)
        {
            for (int i = 0; i < dx.Length; i++)
            {
                int xx = x + dx[i];
                int yy = y + dy[i];
                int zz = z + dz[i];

                if (xx < 0 || yy < 0 || zz < 0) continue;
                if ( yy >= dimensionSize || xx >= dimensionSize|| zz >= dimensionSize) continue;
                if (visited[xx, yy, zz]) continue;
                //if (inMatrix[xx,yy,zz] == bloco intransponivel) continue; 

                xq.Add(xx);
                yq.Add(yy);
                zq.Add(zz);

                visited[xx, yy, zz] = true;
                nodes_left_in_next_layer++;
                prev[xx, yy, zz] = new Vector3(x, y, z);
            }
        }

        int solve()
        {
            bool setPrev = false;
            Vector3 prevv = start;
            visited[toInt(start.x), toInt(start.y), toInt(start.z)] = true;

            xq.Add(start.x);
            yq.Add(start.y);
            zq.Add(start.z);
            
            while (xq.Count > 0)
            {
                float x = xq[xq.Count - 1];
                xq.RemoveAt(xq.Count - 1);
                
                float y = yq[yq.Count - 1];
                yq.RemoveAt(yq.Count - 1);

                float z = zq[zq.Count - 1];
                zq.RemoveAt(zq.Count - 1);

                if (Util.vec3eq(inMatrix[Util.toInt(x), Util.toInt(y), Util.toInt(z)], end))
                {
                    reached_end = true;
                    break;
                }

                explore(Util.toInt(x), Util.toInt(y), Util.toInt(z));
                nodes_left_in_layer--;

                //prev[toInt(x), toInt(y), toInt(z)] = prevv; //prev of start is start

                if (setPrev)
                {
                    prevv.x = x;
                    prevv.y = y;
                    prevv.z = z;

                    setPrev = false;
                }
                if (nodes_left_in_layer == 0)
                {
                    nodes_left_in_layer = nodes_left_in_next_layer;
                    nodes_left_in_next_layer = 0;
                    move_count++;

                    setPrev = true;
                }
        
            }

            if (reached_end)
            {
                Debug.Log("move count " + move_count);
                return move_count;
            }
            else
            {
                return -1;
            }
        }

        solve();

        List<Vector3> reconstruct(){

            List<Vector3> path = new List<Vector3>();
            for (Vector3 at = end;
                !Util.vec3eq(at, start) ;
                at = prev[toInt(at.x), toInt(at.y), toInt(at.z)])
            {
                path.Add(at);
            }
            path.Add(start);
            path.Reverse();
            //TODO: check for disjoint graph
            if (Util.vec3eq(path[0], start))
            {
                return path;
            }
            else
            {
                return null;
            }
        }

        return reconstruct();
    }

    //prevent float point issues
    public static int toInt(float n)
    {
        return (int)Math.Round(n);
    }
}