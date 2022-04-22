using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreakPlatform : MonoBehaviour
{
    public float BreakTime = 3f;
    public float HealTime = 5f;

    private bool CanBreak;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        CanBreak = true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" & CanBreak)
        {
            CanBreak = false;
            anim.SetBool("Activate", true);
            Invoke("Break", BreakTime);
        }
    }

    void Break()
    {
        gameObject.SetActive(false);
        Invoke("Heal", HealTime);
    }

    void Heal()
    {
        gameObject.SetActive(true);
        anim.SetBool("Activate", false);
        CanBreak = true;
    }
}
