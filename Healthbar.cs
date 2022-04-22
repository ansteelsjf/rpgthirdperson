
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Healthbar : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

    private float hitpoint = 150;
    private float maxHitpoint = 150;


    public Camera main_camera;
    public GameObject backgroundimage;
    public GameObject nojob;
    public GameObject receivejob;
    public GameObject finishjob;
    
    


    private void Start()
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }
    private void TakeDamage(float damage)
    {
        hitpoint -= damage;
        if (hitpoint < 0)
        {
            hitpoint = 0;
            Debug.Log("Dead");
            Destroy(this.gameObject);
            Destroy(backgroundimage.gameObject);
            receivejob.SetActive(false);
            finishjob.SetActive(true);
            nojob.SetActive(false);

        }
        UpdateHealthbar();
    }
    private void HealDamage(float heal)
    {
        hitpoint += heal;
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        UpdateHealthbar();
    }
    void OnGUI()
    {

        Vector3 worldPosition = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);

        Vector2 position = main_camera.WorldToScreenPoint(worldPosition);

        //Debug.Log(position);

        backgroundimage.transform.position = position;

    }
}
