using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
      
    }

    public Vector3 getRespawnPoint()
    {
        return new Vector3(transform.position.x, transform.position.y, 0f);
    }
}
