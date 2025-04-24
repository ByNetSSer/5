using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisDrawer : MonoBehaviour
{
    [SerializeField] private CustomAxis xAxis;
    [SerializeField] private CustomAxis yAxis;
    [SerializeField] private CustomAxis zAxis;

    [SerializeField] private Transform originPosition;

    private void OnDrawGizmos()
    {
        Gizmos.color = xAxis.AxisColor;
        Gizmos.DrawRay(originPosition.position, xAxis.AxisVector);
        Gizmos.DrawRay(originPosition.position, -xAxis.AxisVector);

        Gizmos.color = yAxis.AxisColor;
        Gizmos.DrawRay(originPosition.position, yAxis.AxisVector);
        Gizmos.DrawRay(originPosition.position, -yAxis.AxisVector);

        Gizmos.color = zAxis.AxisColor;
        Gizmos.DrawRay(originPosition.position, zAxis.AxisVector);
        Gizmos.DrawRay(originPosition.position, -zAxis.AxisVector);
    }
}

[System.Serializable]
public struct CustomAxis
{
    public string AxisName;
    public Color AxisColor;
    public Vector3 AxisDirection;
    public float AxisMagnitude;

    public Vector3 AxisVector => AxisDirection * AxisMagnitude;
}
