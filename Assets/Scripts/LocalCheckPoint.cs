using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCheckPoint : MonoBehaviour
{
    private bool Used = false;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (!Used)
            {
                coll.gameObject.GetComponent<CharacterStats>().CheckPoint = this.transform.position;
                Used = true;
            }
        }
    }
}
