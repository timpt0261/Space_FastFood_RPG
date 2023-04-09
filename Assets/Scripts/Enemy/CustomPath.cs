using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomPath : MonoBehaviour
{
    [SerializeField]
    private Transform[] points;
    
    [SerializeField]
    [Range(4, 20)]
    private int numPoints = 4;

    [SerializeField]
    private int totalDistance = 10;

    private List<Vector3> path = new List<Vector3>();
    private int numSides = 4; // Start with a square

    void Start()
    {
        CreatePath();
    }

    void CreatePath()
    {
        int prevNumSides = numSides;
        numSides = Mathf.Clamp(numSides, 4, numPoints);

        if (numSides != prevNumSides)
        {
            path.Clear();

            // Calculate the positions of the points to form a regular n-gon
            for (int i = 0; i < numSides; i++)
            {
                float angle = i * Mathf.PI * 2f / numSides;
                Vector3 position = points[i % numPoints].position;
                position.x += totalDistance * Mathf.Cos(angle);
                position.z += totalDistance * Mathf.Sin(angle);
                path.Add(position);
            }

            // Smooth out the path
            for (int i = 0; i < path.Count; i++)
            {
                Vector3 nextPoint = path[(i + 1) % path.Count];
                Vector3 prevPoint = path[(i - 1 + path.Count) % path.Count];
                Vector3 tangent = (nextPoint - prevPoint).normalized;
                Vector3 normal = Vector3.Cross(tangent, Vector3.up);
                path[i] -= normal * (totalDistance / numSides) / 2f;
            }

            // Align the first position to the current position
            Vector3 offset = transform.position - path[0];
            for (int i = 0; i < path.Count; i++)
            {
                path[i] += offset;
            }

            for (int i = 0; i < numPoints; i++) 
            {
                points[i].position = path[i];
            }
        }
    }

    void OnDrawGizmos()
    {
        CreatePath();
        Gizmos.color = Color.white;
        for (int i = 0; i < path.Count; i++)
        {
            if (i == 0)
            {
                Gizmos.DrawLine(path[path.Count - 1], path[i]);
            }
            else
            {
                Gizmos.DrawLine(path[i - 1], path[i]);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            numSides++;
        }
    }

}
