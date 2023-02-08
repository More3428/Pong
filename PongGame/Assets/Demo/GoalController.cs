using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GoalController : MonoBehaviour
{
    public UnityEvent onTriggerEnter; 
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            onTriggerEnter.Invoke();
            Debug.Log("Goal!");
        }
    }
}
