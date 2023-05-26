using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    public World world;    
    public void Start()
    {
        
    }
    public void Reset()
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.GetComponent<Transform>().position = this.transform.parent.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Goal")
        {
            world.Advance();
            Reset();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.LogFormat("{0} trigger exit {1}",this, other);
        if(other.name == "Container")
        {
            world.LoseLive();
            Reset();
        } 
    }
}
