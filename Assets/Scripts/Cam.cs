using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    /*
    [SerializeField] private Transform player;
    [SerializeField] private Transform cameraTransform;

    private Vector3 cameraOffset;
    private Vector3 prevPosition;
    private float rotationSpeed;
    private float rotationX;
    private float rotationY;
    private float rotationDistance;
    private float rotationAngle;


    // Start is called before the first frame update
    private void Start()
    {   
        cameraOffset = new Vector3 (0f, 4f, -6f);
        rotationSpeed = 0.05f;
        rotationDistance = 3f;
        rotationAngle = 0f;
        cameraTransform.transform.rotation = Quaternion.Euler(20, 0, 0);

        
    }

    // Update is called once per frame
    void Update()
    {   
        // figure out camera position
        Vector3 cameraEndPosition = new Vector3 (player.transform.position.x, 0f, player.transform.position.z) + cameraOffset;

        cameraTransform.position = Vector3.Lerp (cameraTransform.position, cameraEndPosition, 0.8f);

        // rotation using arrow keys
        if (Input.GetKey(KeyCode.RightArrow)){
            rotationAngle += rotationSpeed;
        } else if (Input.GetKey(KeyCode.LeftArrow)){
            rotationAngle -= rotationSpeed;
        }

        cameraTransform.transform.rotation = Quaternion.Euler(20, rotationAngle, 0);

         rotation using the mouse
        if (false){
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            
            rotationX -= mouseY;
            rotationY -= mouseX;

            cameraTransform.transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);

            cameraEndPosition = player.transform.position - (cameraTransform.transform.forward * rotationDistance) + cameraOffset;
        }
        

    }

    */
}
