using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordfly : MonoBehaviour

{
    


    float timeAlive = 0f;


    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if (timeAlive > 5)
        {
            gameObject.SetActive(false);
            timeAlive = 0f;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "enemy")

        {
            float damage = 10f;
            collision.gameObject.SendMessageUpwards("TakeDamage", damage);
            Debug.Log("success");
        }
    }




    


}
