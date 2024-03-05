using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    bool cheeseCheck;
    //movement variables
    Rigidbody rb;
    public float MoveSpeed;

    float horInput;
    float verInput;

    public Transform orientation;
    Vector3 moveDirection;

    //velocity variables
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public float groundDrag;

    //slope variables
    public float maxSlopeAngle;
    private RaycastHit slopeHit;

// pause stuff
    bool isPaused = false;
    public GameObject Canvas;

    public FirstPersonCamera camera;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cheeseCheck = false;
        Canvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        PlayerInput();
        SpeedControl();

        //handle drag
        if(grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused == false) {
            Debug.Log("GAME PAUSED");
            Paused();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isPaused == true) {
            Debug.Log("GAME UNPAUSED");
            
            
            unPaused();
        }
         if (Input.GetKeyDown("joystick button 1") && isPaused == false) {
            Debug.Log("GAME PAUSED");
            Paused();
        }
        else if (Input.GetKeyDown("joystick button 1") && isPaused == true) {
            Debug.Log("GAME UNPAUSED");
            
            
            unPaused();
        }

        
    }
    
    void Paused(){
        isPaused = true;
        camera.enabled = false;
        Canvas.gameObject.SetActive(true);
        Time.timeScale = 0;
        
        
        //SceneManager.LoadScene ("PauseScreen");
    }
     void unPaused(){
        isPaused = false;
        camera.enabled = true;
        Canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
        
        
        
        //SceneManager.LoadScene ("PauseScreen");
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void PlayerInput()
    {
        horInput = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        verInput = Input.GetAxisRaw("Vertical") * MoveSpeed;
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verInput + orientation.right * horInput;
        rb.AddForce(moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);

        //on slope
        if(OnSlope())
        {
            rb.AddForce(GetSlopeMoveDirection() * MoveSpeed * 20f, ForceMode.Force);
            if(rb.velocity.y > 0)
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        //turn gravity off on slope
        rb.useGravity = !OnSlope();
    }

    private void SpeedControl()
    {
        //limiting slope speed
        if(OnSlope())
        {
            if(rb.velocity.magnitude > MoveSpeed)
                rb.velocity = rb.velocity.normalized * MoveSpeed;
        }
        else
        {
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
             //limit velocity if needed
            if(flatVel.magnitude > MoveSpeed)
            {
                Vector3 limitedVel = flatVel.normalized * MoveSpeed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

     
    }

    private bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Cheese")
        {
            cheeseCheck = true;
            Destroy(col.collider.gameObject);
            print("This cheese looks great!");
        }

        if (col.gameObject.name == "cat")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScreen");
        }
            if (col.gameObject.name == "End")
            {
                if(cheeseCheck == true)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    SceneManager.LoadScene("WinScreen");
                }
            else
                {
                    print("I want some cheese");
                }
            }


    }
}
