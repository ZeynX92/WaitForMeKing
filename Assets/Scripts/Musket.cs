using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musket : MonoBehaviour
{
    public float offset;
    public float Impulse = 2.5f;
    public Transform shotDir;

    private float timeShot;
    public float startTime;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.z = 0;


        if (timeShot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                transform.parent.gameObject.GetComponent<CharacterMove>().GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                transform.parent.gameObject.GetComponent<CharacterMove>().GetComponent<Rigidbody2D>().AddForce(-1 * difference.normalized * Impulse, ForceMode2D.Impulse);
                timeShot = startTime;
            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }

    }

}