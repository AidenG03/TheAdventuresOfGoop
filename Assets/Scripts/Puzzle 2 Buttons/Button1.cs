using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{
    public int number1;

    // Start is called before the first frame update
    void Start()
    {
        number1 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "Player"){
            if (number1 < 9){
                number1++;
            }
            else {
                number1 = 0;
            }
            print(number1);
        }
    }
}
