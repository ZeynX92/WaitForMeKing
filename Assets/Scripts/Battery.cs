using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public float JumpTime = 1f;

    public Collider2D buffer;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<CharacterMove>().jumpCount = 2;
            gameObject.SetActive(false);

            buffer = coll;

            Invoke("BatteryDisable", JumpTime);
        }
    }

    void BatteryDisable()
    {
        buffer.gameObject.GetComponent<CharacterMove>().jumpCount = 1;
        gameObject.SetActive(true);
    }
}

