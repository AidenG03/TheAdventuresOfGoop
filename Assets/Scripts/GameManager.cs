using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public Box box;
    public Cam cam;
    
    public Button1 num1;
    public Buttons2 num2;
    public Button3 num3;
    public Button4 num4;
    public bool puzzle1Correct = false;
    public bool puzzle2Correct = false;
    public bool enterFinalRoom = false;
    public bool gameWon = false;

    // as soon as game starts
    public void Awake () {

        // Check if the singleton exists
        if (instance == null){

            instance = this;
            DontDestroyOnLoad (gameObject);
        }

        // Destroy the game object if singleton does exist
        else {
            Destroy (gameObject);
        }
    }

    public void Update () {
        if (Input.GetKey (KeyCode.Escape)){
            Application.Quit();
        }
    }
}
