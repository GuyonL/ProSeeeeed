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

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            Vector3 treePosition = new Vector3(transform.position.x, hit.gameObject.GetComponent<Renderer>().bounds.max.y, 0.0f);

            Object.Destroy(this.gameObject);

            GameObject treeInstance = Instantiate(tree, treePosition, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0.0f);
	}
}
