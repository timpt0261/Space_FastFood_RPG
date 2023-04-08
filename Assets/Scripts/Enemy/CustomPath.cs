using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomPath : MonoBehaviour
{

    [SerializeField]
    [Range(0, 20)]
    private int numWaypoints = 5;

    [SerializeField]
    private float totalDistance = 10.0f;

    [SerializeField]
    private Transform[] _customPath = new Transform[20];

    private void Awake()
    {
        
        for (int i = 0; i < numWaypoints; i++) 
        {
            
        }
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.magenta;
        Handles.DrawDottedLine(_customPath[numWaypoints].localPosition, _customPath[0].localPosition, 5f);
        for (int i = 0; i < numWaypoints-1; i++) 
        {
            var _pastPostion = _customPath[(i-1) % _customPath.Length];
            Handles.DrawDottedLine(_customPath[i].localPosition, _pastPostion.localPosition, 5f);
        }
        
    }
}
