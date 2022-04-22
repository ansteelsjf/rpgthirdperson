using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class goblinfight : MonoBehaviour
{


	public Animator anim;

	public float runSpeed = 0.5f;
	public float walkSpeed = 0.3f;

	public Transform playerposition;
	public Transform goblinlookatposition1;
	public Transform goblinlookatposition2;
	private bool Faceleft = true;
	



	// Use this for initialization
	void Start()
	{
		anim.SetInteger("state", 4);



	}

	// Update is called once per frame
	void Update()
	{

		if (
			(Mathf.Abs(playerposition.transform.position.x - this.transform.position.x) < 10f) &&

			(Mathf.Abs(playerposition.transform.position.z - this.transform.position.z) < 10f)

			) //run_idle
		{
			
			transform.localScale = new Vector3(1, 1, 1);
			this.transform.LookAt(playerposition.transform);
			this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, 0);
			//anim.SetBool("run", true);//run
			anim.SetInteger("state", 1);
			runSpeed = 0.5f;
			if (
			(Mathf.Abs(playerposition.transform.position.x - this.transform.position.x) < 2f) &&

			(Mathf.Abs(playerposition.transform.position.z - this.transform.position.z) < 2f)

			)
			{
				transform.Translate(new Vector3(0, 0, 0), Space.Self);
				anim.SetInteger("state", 2);
			}
			else

				transform.Translate(new Vector3(0, 0, runSpeed * Time.deltaTime), Space.Self);
		}
		
		
		
		else if (Faceleft == true)
		{
			anim.SetInteger("state", 4);
			transform.Translate(new Vector3(0, 0, walkSpeed * Time.deltaTime), Space.Self);
			if (Mathf.Abs(goblinlookatposition1.transform.position.z - this.transform.position.z) < 1f)
			{
				transform.localScale = new Vector3(1, 1, -1);
				Faceleft = false;
			}
		}
		else if (Faceleft == false)
		{
			transform.Translate(new Vector3(0, 0, -walkSpeed * Time.deltaTime), Space.Self);
			if ((Mathf.Abs(goblinlookatposition2.transform.position.z - this.transform.position.z) < 1f))
			{
				transform.localScale = new Vector3(1, 1, 1);
				Faceleft = true;
			}
		}

















	}
}
