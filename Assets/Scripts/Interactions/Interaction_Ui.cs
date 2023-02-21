using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interaction_Ui : MonoBehaviour
{
    private Camera _main;

    private void Start()
    {
        _main = Camera.main;
        
    }

    private void LateUpdate()
    {
        var rotation = _main.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
}
