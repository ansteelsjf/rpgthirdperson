using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floortriggerzone : MonoBehaviour
{
    public bool isDamaging;
    public float damage = 10;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
            col.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damage);
    }
}
