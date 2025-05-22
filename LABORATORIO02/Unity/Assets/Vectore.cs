using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Vectore : MonoBehaviour
{
    public Vector3 goal = new Vector3(5,0,4);
    public float speed = 0.1f;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        this.transform.Translate(goal.normalized * speed * Time.deltaTime);
    }
}
