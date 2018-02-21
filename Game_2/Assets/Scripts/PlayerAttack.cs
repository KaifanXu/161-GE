using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    public Rigidbody bulletPrefab;

    float attackRate = 0.5f;
    float coolDown;

    // Update is called once per frame
    void Update () {
        if (Time.time >= coolDown)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                BulletAttack();
            }
        }
    }
    void BulletAttack()
    {
       // bulletPrefab = GetComponent<Rigidbody>();
        //利用as Rigidbody将Instantiate的GameObject强制转换为Rigidbody类型。  
        Rigidbody bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Rigidbody;
        bPrefab.AddForce(Vector3.right * 500);
        coolDown = Time.time + attackRate;
    }
}
