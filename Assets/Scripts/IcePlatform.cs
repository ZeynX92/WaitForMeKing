using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcePlatform : MonoBehaviour

{
    public Collider2D Buffer;
    public float IceImpulse = 2;
    public float IceSpeedTime = 1f;


    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {

            coll.gameObject.GetComponent<CharacterMove>().speed *= IceImpulse;
            Buffer = coll;

        }
    }

    void stopIceSpeed()
    {

        {
            Buffer.gameObject.GetComponent<CharacterMove>().speed /= IceImpulse;

        }
    }

    public void OnTriggerExit2D(Collider2D coll)
    { 
        if (coll.tag == "Player")
        {
          Buffer = coll;
          Invoke("stopIceSpeed", IceSpeedTime);
        }
    }
 }
