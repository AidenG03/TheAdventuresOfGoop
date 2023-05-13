using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPath : MonoBehaviour
{
    [SerializeField] Transform trans;
    private Vector3 targetPosition;
    private Vector3 startingPostion;
    private Vector3 playerOffet;
    private bool reachedPlayer;

    // Start is called before the first frame update
    void Start()
    {
         targetPosition = new Vector3 (93, 15, 243);
         startingPostion = trans.position;
         playerOffet = new Vector3 (0, .7f, 0);
         reachedPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){

        if(GameManager.instance.puzzle2Correct == true && reachedPlayer == false){
            
            trans.position = Vector3.MoveTowards(trans.position, targetPosition, 12f * Time.deltaTime);
            
            if (trans.position == targetPosition){
                reachedPlayer = true;
            }            
           
        }
    }

    private void OnCollisionStay (Collision collision){
        
        if (collision.gameObject.tag == "Player" && trans.position != startingPostion){
            trans.position = Vector3.MoveTowards(trans.position, startingPostion, 12f * Time.deltaTime);
            GameManager.instance.player.playerTransform.position = trans.position + playerOffet;
        }

    }
}
