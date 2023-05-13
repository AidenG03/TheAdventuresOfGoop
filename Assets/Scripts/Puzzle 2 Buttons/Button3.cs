using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3 : MonoBehaviour
{
    public int number3;

    // Start is called before the first frame update
    void Start()
    {
        number3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "Player"){
            if (number3 < 9){
                number3++;
            }
            else {
                number3 = 0;
            }
            print(number3);
        }
    }
}
