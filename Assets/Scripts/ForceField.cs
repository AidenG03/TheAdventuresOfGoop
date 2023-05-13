using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.box.pressed == true || Input.GetKey (KeyCode.RightAlt)){
            GameManager.instance.puzzle1Correct = true;
            Destroy(this.gameObject);
            GUIManager.instance.hint.text = "Press 'Enter' to recieve a hint.";
        }
    }
}
