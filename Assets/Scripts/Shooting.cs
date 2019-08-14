using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Camera cam;
    private Vector3 firePoint;
    public GameObject seed;
    public GameObject player;
    [SerializeField] private float force;
    [SerializeField] private float offset; 

    // Start is called before the first frame update
    void Start()
    { 
        cam = Camera.main;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        firePoint = cam.ScreenToWorldPoint(new Vector3(x, y, -cam.transform.position.z));
        firePoint = new Vector3(firePoint.x, firePoint.y, 0);
        transform.LookAt(firePoint);

        int inventory = player.GetComponent<CharacterScript>().getInventory();
        if (inventory > 0 && Input.GetMouseButtonDown(0))
        {
            Shoot();
            player.GetComponent<CharacterScript>().removeSeed();
        }
    }

    // Shoot the seed towards a point
    void Shoot()
    {
        Vector3 startPosition = transform.position + Vector3.Normalize(firePoint - transform.position) * offset;
        GameObject seedInstance = Instantiate(seed, startPosition, transform.rotation);
        seedInstance.GetComponent<Rigidbody>().AddForce((firePoint - transform.position).normalized * force);
    }
}
