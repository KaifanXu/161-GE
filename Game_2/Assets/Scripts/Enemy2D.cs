using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour {
    public GameManager gameManager;

    float startPos;
    float endPos;

    public int unitsToMove = 5;

    public int moveSpeed = 2;

    bool moveRight = true;

    int enemyHealth = 1;

    public bool basicEnemy;
    public bool advancedEnemy;

    void Awake(){
        startPos = transform.position.x;
        endPos = startPos + unitsToMove;

        if (basicEnemy){
            enemyHealth = 2;
        }

        if (advancedEnemy){
            enemyHealth = 4;
        }
    }

	
	// Update is called once per frame
    
	void Update () {
        if (moveRight){
            GetComponent<Rigidbody>().position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (GetComponent<Rigidbody>().position.x >= endPos){
            moveRight = false;
        }
        if (moveRight == false){
            GetComponent<Rigidbody>().position -= Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (GetComponent<Rigidbody>().position.x <= startPos){
            moveRight = true;
        }
    }
    

    int damageValue = 1;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameManager.SendMessage("PlayerDamaged", damageValue, SendMessageOptions.DontRequireReceiver);
            gameManager.controller.SendMessage("TakenDamage", SendMessageOptions.DontRequireReceiver);
        }
    }

    void EnemyDamaged(int damage){
        if (enemyHealth > 0){
            enemyHealth -= damage;
        }

        if (enemyHealth <= 0){
            enemyHealth = 0;
            Destroy(gameObject);
            if (basicEnemy)
            {
                gameManager.curEXP += 10;
            }
            if (advancedEnemy)
            {
                gameManager.curEXP += 20;
            }
        }
    }
}
