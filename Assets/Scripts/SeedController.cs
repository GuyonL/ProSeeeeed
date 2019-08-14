using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedController : MonoBehaviour
{
    public GameObject tree;
    public float maxHeight;
    public float growthRate;
    

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = 1.0f;
        growthRate = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            Vector3 treePosition = new Vector3(transform.position.x, 0.0f, transform.position.z);

            Object.Destroy(this.gameObject);

            GameObject treeInstance = Instantiate(tree, treePosition, Quaternion.identity);
            Grow(treeInstance);
            //treeInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    private void FixedUpdate()
    {
       
    }

    void Grow(GameObject treeToGrow)
    {
        while (treeToGrow.transform.localScale.y <= maxHeight)
        {
            treeToGrow.transform.localScale = new Vector3(0.5f, treeToGrow.transform.localScale.y + growthRate, 1.0f);
        }
    }

    //IEnumerator Grow(GameObject newTree)
    //{
    //    for (float scale = 0f; scale >= maxHeight; scale += growthRate)
    //    {
    //        newTree. += growthRate;
    //        newTree.transform.localScale += new Vector3(scale/3, scale, scale/3);
    //        yield return null;
    //    }
    //}
}
