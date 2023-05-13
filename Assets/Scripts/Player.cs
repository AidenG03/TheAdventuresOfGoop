using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField] private Rigidbody body;
    [SerializeField] private Animator animator;
 
    private float playerSpeed;
    private float jumpSpeed;
    private bool isJumping;
    [SerializeField] private bool player1;
    private float rotationSpeed;
    private Vector3 targetPos;
    private Vector3 startingPos;
    private int deaths;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = playerTransform.position;
        playerSpeed = 14f;
        jumpSpeed = 15f;
        isJumping = false;
        rotationSpeed = 5f;
        deaths = 0;
        GameManager.instance.enterFinalRoom = false;
        GameManager.instance.gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {   
       
        Vector3 movementV = Vector3.zero;
        float xMovement = 0;
        float zMovement = 0;
        float currentX = playerTransform.position.x;
        float currentZ = playerTransform.position.z;
        
        float facing = GameManager.instance.cam.transform.eulerAngles.y;
        
        // was testing two different types of movements
        if (player1){

        // sprinting
        if (Input.GetKey (KeyCode.LeftShift)){
            playerSpeed = 30f;
        } else { playerSpeed = 14f; }   

        if (Input.GetKey (KeyCode.W)){
            zMovement = playerSpeed;
        }
        else if (Input.GetKey (KeyCode.S)){
            zMovement = -playerSpeed;
        }

        if (Input.GetKey (KeyCode.A)){
            xMovement = -playerSpeed;
        }
        else if (Input.GetKey (KeyCode.D)){
            xMovement = playerSpeed;
        }

        movementV = new Vector3 (xMovement, body.velocity.y, zMovement);

        Vector3 turnMovement = Quaternion.Euler(0, facing, 0) * movementV;



        if (movementV != Vector3.zero){
            body.velocity = turnMovement;
        }
        } else {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3 (h, 0, v) + playerTransform.position;

            if (h != 0 || v != 0){

                Vector3 toFaceDirction = inputDirection - playerTransform.position;

                Quaternion targetRotation = Quaternion.LookRotation(toFaceDirction);
                playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            float speedValue = Mathf.Max (Mathf.Abs (h), Mathf.Abs (v));
            animator.SetFloat ("Speed", speedValue);
        }
        


        if (Input.GetKey (KeyCode.Space) && isJumping == false){
            DoJump();
        }

    }

    private void OnCollisionEnter (Collision collision){

        // reset the jump
        if (isJumping && (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Button")){
            isJumping = false;
        }

        // don't touch the lava
        if (collision.gameObject.tag == "Lava"){
            playerTransform.position = startingPos;
            GUIManager.instance.hint.text = "THANK GOD IT WAS JUST A DREAM!";
            deaths++;
            GUIManager.instance.nightmares.text = deaths.ToString();
            
        }
        
        // go through final door
        if (collision.gameObject.tag == "Final Door"){
            GameManager.instance.enterFinalRoom = true;
            transform.position = new Vector3(125, 17, 273);
        }

        // winning the game
        if (collision.gameObject.tag == "Invisible Button"){

            targetPos = new Vector3(transform.position.x, transform.position.y + 200, transform.position.z);
            transform.position = targetPos;

            GameManager.instance.gameWon = true;

            GUIManager.instance.hint.text = "YOU DID IT!! LOVE THIS DREAM";
        }

    }

    private void DoJump(){
        isJumping = true;
        body.velocity += Vector3.up * jumpSpeed;
    }
}
