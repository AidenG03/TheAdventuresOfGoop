using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private Transform trans;
    [SerializeField] private Transform spawn;
    [SerializeField] private Rigidbody Ball;
    private Transform target;
    private float rotationSpeed;
    private float shootSpeed;
    private float reload;
    Vector3 correction;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 playerPos = GameManager.instance.player.playerTransform.position;

        correction = new Vector3 (0f, -0.5f, 0f);

        SetTarget (GameManager.instance.player.playerTransform);
        rotationSpeed = 5f;
        shootSpeed = 800f;
        reload = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FaceTarget();

    }

    public void SetTarget (Transform t) {
        target = t;
    }

    private void FaceTarget () { 

        if (target == null)
            return;


        // calc vector from enemy to player
        Vector3 targetVector = target.position - trans.position;

        if (targetVector.magnitude < 40f) {
            Quaternion targetRotation = Quaternion.LookRotation (targetVector);
            trans.rotation = Quaternion.Lerp (trans.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (targetVector.magnitude < 30f){
                Shoot();
            }
        }
        else {
            trans.rotation = Quaternion.Lerp (trans.rotation, Quaternion.identity, rotationSpeed * Time.deltaTime);
        }
    }

    private void Shoot(){
        
        // cooldown for slimeballs
        if (reload > 1000f){
        
        // create new slimeballs and shoot towards the player
        Rigidbody slimeBall = (Rigidbody) Instantiate (Ball, spawn.position, spawn.rotation);

        slimeBall.velocity = ((target.position + correction) - trans.position) * (shootSpeed * Time.deltaTime);
        reload = 0f;

        } else {
            reload += 1f;
        }
        
    }
}
