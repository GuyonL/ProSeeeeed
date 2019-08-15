using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            Vector3 treePosition = new Vector3(transform.position.x, 0.0f, 0.0f);

            Object.Destroy(this.gameObject);

            GameObject treeInstance = Instantiate(tree, treePosition, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
       
    }
}
