using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    private bool Joined = true;

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && Joined)
        {
            coll.gameObject.GetComponent<CharacterMove>().jumpForce *= 1.5f;
            Joined = false;
        }
        else
        {
            coll.gameObject.GetComponent<CharacterMove>().jumpForce /= 1.5f;
            Joined = true;
        }
    }
}
