using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{

    public float maxHeight;
    public float growthRate;
    public float growthTime;

    // Start is called before the first frame update
    void Start()
    {
        maxHeight = 0.32f;
        growthRate = 2.5f;
        growthTime = 1.5f;

        this.gameObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (this.gameObject.transform.lossyScale.y < maxHeight) {
            Vector3 oldScale = this.gameObject.transform.localScale;
            this.gameObject.transform.localScale = Vector3.Lerp(oldScale, oldScale * growthRate, growthTime * Time.deltaTime);
        }
    }
    
}
