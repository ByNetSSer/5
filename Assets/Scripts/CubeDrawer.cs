using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDrawer : MonoBehaviour
{
    [Header("Referencias de pivotes ")]
    [SerializeField] private Transform[] pivots = new Transform[8];

    [Header("Transformaciones")]
    public Vector3 translationVector;
    public Vector3 scaleVector = Vector3.one;

    private void OnDrawGizmos()
    {
        if (pivots.Length != 8) return;

        Gizmos.color = Color.white;
        Vector3[] transformedPoints = new Vector3[8];
        for (int i = 0; i < 8; i++)
        {
            if (pivots[i] == null) return;
            Vector3 scaled = Vector3.Scale(pivots[i].localPosition, scaleVector);
            transformedPoints[i] = scaled + translationVector;
            Gizmos.DrawWireSphere(transformedPoints[i], 0.1f);
        }
        DrawCubeEdges(transformedPoints);
    }

    private void DrawCubeEdges(Vector3[] points)
    {
        int[,] edges = new int[,]
        {
            {0,1}, {1,3}, {3,2}, {2,0},
            {4,5}, {5,7}, {7,6}, {6,4},
            {0,4}, {1,5}, {2,6}, {3,7}
        };

        for (int i = 0; i < edges.GetLength(0); i++)
        {
            Gizmos.DrawLine(points[edges[i, 0]], points[edges[i, 1]]);
        }
    }
}