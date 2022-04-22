using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public Collider[] attackHitboxes;
    AudioSource audiosource;

    // Start is called before the first frame update

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    // Update is called once per frame

    private void Update()
    {
       // if (Input.GetKeyDown(KeyCode.G))
            LaunchAttack(attackHitboxes[0]);
        //if (Input.GetKeyDown(KeyCode.H))

          //  LaunchAttack(attackHitboxes[1]);

    }
    private void LaunchAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach (Collider c in cols)
        {
           
            Debug.Log(c.name );
            float damage = 0;
            switch(c.name)
            {
                case "goblincollider":
                    damage = 2;
                    break;
                    default:
                    Debug.Log("Fail to reach");
                    break;

            }

        
                c.SendMessageUpwards("TakeDamage", damage);
                audiosource.Play();
            
        }



    }

}
