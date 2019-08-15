using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private int inventory;

    public float speed;
    public float jumpSpeed;
    private float jumpTimeCounter;
    public float gravity;
    private bool goingRight = true;

    private CharacterController characterController;
    private Rigidbody rigidBody;

    private bool isGrounded;
    private bool stoppedJumping;


    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        inventory = 5;
        jumpTimeCounter = 5.0f;

        isGrounded = true;
        stoppedJumping = true;

        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Code in FixedUpdate because we are using phyics to move.

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        moveDirection *= speed;

        // Facing
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            goingRight = false;
            transform.eulerAngles = new Vector3(0f, 240f, 0f); 
        }
        else if (goingRight || (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            goingRight = true;
            transform.eulerAngles = new Vector3(0f, 120f, 0f);
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)

        rigidBody.velocity = new Vector3(moveDirection.x * speed, rigidBody.velocity.y - gravity * Time.deltaTime, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed, 0f);
                isGrounded = false;
                stoppedJumping = false;
            }
            else if (!isGrounded && !stoppedJumping)
            {
                //keep jumping!
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, jumpSpeed, 0f);
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            //stop jumping and set your counter to zero.  The timer will reset once we touch the ground again in the update function.
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Tree")
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("PickupSeed"))
        {
            if (inventory < 5)
            {
                Destroy(other.gameObject);
                inventory++;
            }
        }
        else if (other.gameObject.CompareTag("Tree") && transform.position.y > other.gameObject.transform.position.y)
        {
            isGrounded = true;
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
