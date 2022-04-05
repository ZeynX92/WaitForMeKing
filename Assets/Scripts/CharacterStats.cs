using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public Vector3 CheckPoint;
    public Vector3 GlobalCheckPoint;

    public int gearsCount;
    public Text gearText;

    public int HP;
    public int healthCount;

    public Image[] lives;

    public Sprite fullLive;
    public Sprite emptyLive;

    public void Start()
    {
        CheckPoint = new Vector3(-6.235f, -1.919f, 0.0f);
        GlobalCheckPoint = new Vector3(-6.235f, -1.919f, 0.0f);
        gearText.text = $"{gearsCount}";
    }

    public void TakeDamage()
    {
        HP -= 1;
        new WaitForSeconds(1);
        transform.position = CheckPoint;
    }

    public void AddGear(int value)
    {
        gearsCount += value;
        gearText.text = $"{gearsCount}";
    }

    void Update()
    {
        if (HP <= 0)
        {
            transform.position = GlobalCheckPoint;
            HP = healthCount;
        }

        if (HP > healthCount)
        {
            HP = healthCount;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < HP)
            {
                lives[i].sprite = fullLive;
            }
            else
            {
                lives[i].sprite = emptyLive;
            }

            if (i < healthCount)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
