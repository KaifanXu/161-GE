using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controller : MonoBehaviour {
    CharacterController characterController;
    public Renderer rend;
    public float gravity = 10;  
    public float speed = 5;
    public float jumpHeight = 8;

    float damageTaken = 0.2f;

    Vector3 moveDirection = Vector3.zero;
    float horizontal = 0.00f;

    public Rigidbody bulletPrefab;
    float attackRate = 0.3f;
    float coolDown;
    bool lookRight = true;
    // Use this for initialization
    void Start () {
        characterController = GetComponent<CharacterController>();
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //for player's movement
        characterController.Move(moveDirection * Time.deltaTime);
        horizontal = Input.GetAxis("Horizontal");

        moveDirection.y -= gravity * Time.deltaTime;

        if (horizontal == 0.00f){
            moveDirection.x = horizontal * speed;
        }
        
        if (horizontal > 0.00f){
            lookRight = true;
            moveDirection.x = horizontal * speed;
        }
        if(horizontal < -0.00f)
        {
            lookRight = false;
            moveDirection.x = horizontal * speed;
        }
        // for player's jump
        if (characterController.isGrounded){
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.K))
            {
                moveDirection.y = jumpHeight;
            }
        }

        if(Time.time >= coolDown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BulletAttack();
            }
        }

    }

    void BulletAttack()
    {
        if (lookRight)
        {
            
            Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
            bPrefab.AddForce(Vector3.right * 500);
            coolDown = Time.time + attackRate;
        }
        else
        {
            
            Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
            bPrefab.AddForce(- Vector3.right * 500);
            coolDown = Time.time + attackRate;
        }
    }
    
    /*
    public IEnumerator DamageTaken(){
        rend.enabled = false;
        yield return new WaitForSeconds(damageTaken);
        rend.enabled = true;
        yield return new WaitForSeconds(damageTaken);
        rend.enabled = false;
        yield return new WaitForSeconds(damageTaken);
        rend.enabled = true;
        yield return new WaitForSeconds(damageTaken);
        rend.enabled = false;
        yield return new WaitForSeconds(damageTaken);
        rend.enabled = true;
        yield return new WaitForSeconds(damageTaken);
    }
    */
}
