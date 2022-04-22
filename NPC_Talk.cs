using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class NPC_Talk : MonoBehaviour
{

    public GameObject Button;
    public GameObject talkUI;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);
    }
    private void Update()
    {
        if (Button.activeSelf && Input.GetMouseButtonDown(0))
        {
            talkUI.SetActive(true);
        }
    }


}
