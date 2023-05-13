using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeNumbers : MonoBehaviour
{
    [SerializeField] TextMeshPro Code;
    private string firstNum;
    private string secondNum;
    private string thirdNum;
    private string fourthNum;
    private string result;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.puzzle2Correct = false;
        Code = FindObjectOfType<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

        firstNum = GameManager.instance.num1.number1.ToString();
        secondNum = GameManager.instance.num2.number2.ToString();
        thirdNum = GameManager.instance.num3.number3.ToString();
        fourthNum = GameManager.instance.num4.number4.ToString();


        result = firstNum + secondNum + thirdNum + fourthNum;
    
        if (result == "2364" || (Input.GetKey (KeyCode.RightAlt) && Input.GetKey (KeyCode.Alpha2))){
            Code.text = "CORRECT";
            GameManager.instance.puzzle2Correct = true;
            GUIManager.instance.hint.text = "Press 'Enter' to recieve a hint.";
        } else if (GameManager.instance.puzzle2Correct == false){
            Code.text = result;
        }
        
    }

}
