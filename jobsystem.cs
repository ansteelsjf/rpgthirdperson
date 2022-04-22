using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jobsystem : MonoBehaviour
{
    public bool jobshowout;
    // Start is called before the first frame update
    public void PlayGame()
    {
        jobshowout = true;
        gameObject.SendMessage("showjob", jobshowout);
        Debug.Log("showjob");
    }

}
