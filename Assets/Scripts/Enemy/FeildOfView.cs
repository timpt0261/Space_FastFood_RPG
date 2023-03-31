using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FeildOfView : MonoBehaviour
{
    // Ref: https://youtu.be/rQG9aUWarwE

    [SerializeField]
    private float viewRadius;
    [Range(0,360)]
    [SerializeField]
    private float viewAngle;

    [SerializeField]
    private LayerMask obstabcleMask;

    [SerializeField]
    private LayerMask targetMask;

    private List<Transform> visibleTarget = new List<Transform>();

    private void Start()
    {
        StartCoroutine("FindTargertWithDelay", 0.2f);
    }

    IEnumerator FindTargertWithDelay(float delay)
    {
        while (true) 
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        
        }
    }
    void FindVisibleTargets() 
    {
        Collider[] targetsInView = Physics.OverlapSphere(this.transform.position, viewRadius, targetMask);
        for (int i = 0; i < targetsInView.Length; i++) 
        {
            Transform target = targetsInView[i].transform;
            Vector3 dirToTarget = (target.position - this.transform.position).normalized;
            if (Vector3.Angle(this.transform.forward, dirToTarget) < viewAngle/2) 
            {
                float dstTotarget = Vector3.Distance(this.transform.position, target.position);

                if (!Physics.Raycast(this.transform.position, dirToTarget, dstTotarget, obstabcleMask)) 
                {
                    visibleTarget.Add(target);
                }
            }
        }
    }

    private Vector3 DirFromAngle(float angleToDegrees, bool AngleIsGlobal) 
    {
        if (!AngleIsGlobal) 
        {
            angleToDegrees += transform.eulerAngles.y;
        } 
        return new Vector3(Mathf.Sin(angleToDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleToDegrees * Mathf.Deg2Rad));
    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawWireArc(this.transform.position, Vector3.up, Vector3.forward, 360, viewRadius);
        Vector3 viewA = DirFromAngle(-viewAngle/2,false);
        Vector3 viewB = DirFromAngle(viewAngle / 2, false);

        Handles.DrawLine(this.transform.position, transform.position + viewA * viewRadius);
        Handles.DrawLine(this.transform.position, transform.position + viewB * viewRadius);
    }
}
