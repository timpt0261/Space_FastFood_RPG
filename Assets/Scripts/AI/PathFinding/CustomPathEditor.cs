using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// Ref https://www.youtube.com/watch?v=ENhxtZZjJSA&t=490s

[CustomEditor(typeof(EnemyNavMesh))]
public class CustomPathEditor : Editor
{
    private EnemyNavMesh targetPath;

    private void OnSceneGUI()
    {
        targetPath = (EnemyNavMesh)target;
        Handles.color = Color.green;

        var postions = targetPath.customPath;

        for (int i = 1; i < postions.Length + 1; i++)
        {

            var previousPoint = postions[i - 1];
            var currentPoint = postions[i % postions.Length];

            Handles.DrawDottedLine(previousPoint, currentPoint, 10f);
        }

        var polygonPoints = new Vector3[postions.Length];

        for (int i = 0; i < postions.Length; i++)
        {
            polygonPoints[i] = postions[i];
            postions[i] = Handles.PositionHandle(postions[i], Quaternion.identity);
        }

        Handles.color = new Color(0, 1, 1, .2f);
        Handles.DrawAAConvexPolygon(polygonPoints);
    }
}
