using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{

    public TextMeshProUGUI hint;
    public TextMeshProUGUI nightmares;
    public static GUIManager instance;

    public void Awake () {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad (gameObject);
        } else {
            Destroy (gameObject);
        }
    }


    private void Start () {
        hint.text = "Press 'Enter' to recieve a hint.";
        nightmares.text = "0";
    }


    private void Update () {

        if (Input.GetKey (KeyCode.Return)){
            GiveHint();
        }

        if (GameManager.instance.gameWon == false){

            if (GameManager.instance.enterFinalRoom == true){
            hint.text = "There is an invisible button in here... good luck finding it.";
        }
        } else {
            hint.text = "You did it!!! LOVE THIS DREAM";
        }
        
    }
    private void GiveHint(){

        if (GameManager.instance.puzzle1Correct == false){
            hint.text = "Opposites Attract";
        }
        else if (GameManager.instance.puzzle2Correct == false){
            hint.text = "Sometimes a different point of view is needed.";
        }
        else if (GameManager.instance.enterFinalRoom == false){
            hint.text = "Did you take the magic bridge?";
        }
    }

}
