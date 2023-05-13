using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button4 : MonoBehaviour
{
    public int number4;

    // Start is called before the first frame update
    void Start()
    {
        number4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter (Collision collision){
        if (collision.gameObject.tag == "Player"){
            if (number4 < 9){
                number4++;
            }
            else {
                number4 = 0;
            }
            print(number4);
        }
    }
}
