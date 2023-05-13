using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons2 : MonoBehaviour
{
    public int number2;

    // Start is called before the first frame update
    void Start()
    {
        number2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "Player"){
            print("BUTTON HIT");

            if (number2 < 9){
                number2++;
            }
            else {
                number2 = 0;
            }
            print(number2);
        }
    }
}
