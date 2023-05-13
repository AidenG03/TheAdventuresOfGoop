using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPit : MonoBehaviour
{

    [SerializeField] private Transform spawn;
    [SerializeField] private Rigidbody Ball;
    private Transform target;
    private float rotationSpeed;
    private float shootSpeed;
    private float reload;


    // Start is called before the first frame update
    void Start()
    {
        SetTarget (GameManager.instance.player.playerTransform);
        shootSpeed = 800f;
        reload = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FaceTarget();

        if (GameManager.instance.enterFinalRoom == true && GameManager.instance.gameWon == false){
            Shoot();
        }
    }


    private void SetTarget (Transform t) {
        target = t;
    }

    private void FaceTarget(){
        // calc vector from enemy to player
        Vector3 targetVector = target.position - spawn.position;
    }
    private void Shoot(){
        
        // cooldown for balls
        if (reload > 10f){
        
        // create new balls to fill the room
        Rigidbody slimeBall = (Rigidbody) Instantiate (Ball, spawn.position, spawn.rotation);

        slimeBall.velocity = (target.position - spawn.position) * (shootSpeed * Time.deltaTime);
        reload = 0f;

        } else {
            reload += 1f;
        }
        
    }
}
