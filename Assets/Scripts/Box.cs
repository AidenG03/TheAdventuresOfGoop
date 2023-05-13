using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private GameObject button;
    [SerializeField] private bool correctBox;
    private bool ableToPickUp;
    private bool pickedUp;
    public bool pressed;
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        ableToPickUp = false;
        pickedUp = false;
        pressed = false;
        offset = new Vector3 (0f, 2f, 0f);
        GameManager.instance.puzzle1Correct = false;
    }

    // Update is called once per frame
    void Update()
    {
        // see if the player in within range
        findPlayer();

        // if the player can pick it up and hasn't already let them do so if they press 'E'
        if (ableToPickUp == true){
            if (Input.GetKeyDown (KeyCode.E)){
                pickedUp = !pickedUp;
            }
        }

        // while the box is picked up, carry it
        if (pickedUp == true){
            trans.position = GameManager.instance.player.playerTransform.position + offset;
        }
    }

    private void OnCollisionEnter (Collision collision){
        if ((collision.gameObject.tag == "Button" && correctBox == true)){
            print("BUTTON ACTIVATED");
            pressed = true;
            GameManager.instance.puzzle1Correct = true;
        }
    }
    private void findPlayer () {

        // calculating vector between player and box
        Vector3 playerDistance = GameManager.instance.player.playerTransform.position - trans.position;

        if (playerDistance.magnitude < 3f){
            GUIManager.instance.hint.text = "press 'E' to pick up box";
            ableToPickUp = true;
        }
        else {
            ableToPickUp = false;
        }
    }
}
