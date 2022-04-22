using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class tryclicktomove2 : MonoBehaviour
{
    public CharacterController controller;
    public float player_speed = 2.0f;
    public Camera main_camera;
    public Ray ray;
    public GameObject lookatposition;
    public Animator anim;
    public Animator goblinanim;
    public Transform NPCposition;
    public GameObject talkUI;
    public GameObject nojob;
    public GameObject receivejob;
    public GameObject finishjob;
    public GameObject goblin;
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {



        if (Input.GetMouseButtonDown(0))
        {

            ray = main_camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycasthit = Physics.RaycastAll(ray, 50);
            for (int i = 0; i < raycasthit.Length; i++)
            {
                print(raycasthit[i].collider.tag);
                print(raycasthit[i].point);
                if (raycasthit[i].collider.CompareTag("floor"))

                {
                    lookatposition.transform.position = raycasthit[i].point;
                    this.transform.LookAt(lookatposition.transform);
                    this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
                    anim.SetInteger("state", 1);

                }

            }

        }
        if (anim.GetInteger("state") == 1)
        {
            if (Mathf.Abs(transform.position.x - lookatposition.transform.position.x) < 0.1f && Mathf.Abs(transform.position.z - lookatposition.transform.position.z) < 0.1f)
            {
                anim.SetInteger("state", 0);

            }
            else
                controller.transform.Translate(new Vector3(0, 0, player_speed * Time.deltaTime), Space.Self);
        }
        if (goblin &&
            (Mathf.Abs(this.transform.position.x - goblin.transform.position.x) < 2f) &&
            (Mathf.Abs(this.transform.position.z - goblin.transform.position.z) < 2f)
            ) //battle_idle
        {
         
            //anim.SetBool("attack", true);
            anim.SetInteger("state", 2);
            this.transform.LookAt(goblin.transform);
            this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);

        }

        if (
            (Mathf.Abs(transform.position.x - NPCposition.position.x) < 4f) &&
            (Mathf.Abs(transform.position.z - NPCposition.position.z) < 4f)
            )

        {
            talkUI.SetActive(true);
            nojob.SetActive(false);
            receivejob.SetActive(true);

        }
        else
            talkUI.SetActive(false);
    }

}
