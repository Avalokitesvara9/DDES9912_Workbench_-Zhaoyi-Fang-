using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EvenOnBump : MonoBehaviour
{
   public UnityEvent onBump; // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
     {
       onBump.Invoke();
     }
    
}