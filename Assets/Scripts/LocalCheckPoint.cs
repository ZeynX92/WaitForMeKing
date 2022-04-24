using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalCheckPoint : MonoBehaviour
{
    public bool Used = false;
    private Animator anim;
    // TODO: ¬озвращать патроны к исходному состо€нию

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            if (!Used)
            {
                anim.SetBool("Used", true);
                coll.gameObject.GetComponent<CharacterStats>().HP += 1;
                coll.gameObject.GetComponent<CharacterStats>().CheckPoint = this.transform.position;
                Used = true;
                GameObject[] CheckPoints = coll.gameObject.GetComponent<CharacterStats>().CheckPoints;
                for (int i = 0; i < CheckPoints.Length; i++)
                {
                    if (CheckPoints[i] != this.gameObject)
                    {
                        CheckPoints[i].GetComponent<Animator>().SetBool("Used", false);
                    }
                }

            }
        }
    }
}
