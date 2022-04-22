using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
            
            newBullet.transform.position = transform.position + transform.up;
            newBullet.GetComponent<Rigidbody>().velocity = transform.up*10;
            newBullet.SetActive(true);
            audioSource.Play();
            
        }
    }
}
