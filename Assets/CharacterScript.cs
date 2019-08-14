using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private int inventory;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private CharacterController characterController;

    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        inventory = 5;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        moveDirection *= speed;

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity* Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Tree" && Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    pickUpSeed();
        //}
        if (collision.gameObject.tag == "PickupSeed" && Input.GetKeyDown(KeyCode.DownArrow))
        {
            pickUpSeedFromGround(collision.gameObject);
            
        }
    }

    void pickUpSeedFromGround(GameObject seed)
    { 
        if (inventory < 5)
        {
            addSeed();
            Object.Destroy(seed);
        }

    }

    public void addSeed()
    {
        inventory++;
    }

    public void removeSeed()
    {
        if (inventory > 0)
        {
            inventory--;
        }
    }

    public int getInventory()
    {
        return inventory;
    }
}
