using System.Collections.Specialized;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    Mesh mesh;
    float fov;
    Vector3 origin;
    float statingAngle;
    float viewDistance;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 360f;
        origin = Vector3.zero;
        viewDistance = 10f;
    }

    void LateUpdate() {
        int rayCount = 360;
        float angle = 0f;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 x = new Vector3(Mathf.Cos(angle * Mathf.PI/180f), Mathf.Sin(angle * Mathf.PI/180f));
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, x, viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + x * viewDistance;
            }
            else 
            {
                vertex = raycastHit2D.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;
        }
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 50f);
    }
    public void SetOrigin(Vector3 origin) 
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDirection) 
    {
        aimDirection = aimDirection.normalized;
        float n = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        statingAngle = n - fov / 2f;
    }
    
}
