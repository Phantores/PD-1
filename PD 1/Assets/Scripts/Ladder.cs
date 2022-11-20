using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    
    
    void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SendMessage("Climbing");
        
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SendMessage("NotClimbing");
        
    }
}
