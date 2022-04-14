using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public Vector3 CheckPoint;
    public Vector3 GlobalCheckPoint;

    public int gearsCount; // TODO: общее кол-во шестерней static -- везде
    public Text gearText;
    public Text CartridgeText;

    public int cartridgeCount = 3;

    public int HP;
    public int healthCount;

    public Image[] lives;
    public GameObject[] CheckPoints;

    public Sprite fullLive;
    public Sprite emptyLive;

    public void Start()
    {
        CheckPoint = new Vector3(-6.235f, -1.919f, 0.0f);
        GlobalCheckPoint = new Vector3(-6.235f, -1.919f, 0.0f);
        gearText.text = $"{gearsCount}";
        CartridgeText.text = $"Cartridges: {cartridgeCount}";
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

    public void AddCartridge(int value)
    {
        cartridgeCount += 1;
        CartridgeText.text = $"Cartridges: {cartridgeCount}";
    }

    void Update()
    {
        CartridgeText.text = $"Cartridges: {cartridgeCount}";

        if (HP <= 0)
        {
            transform.position = GlobalCheckPoint;
            DisableCheckPoints();
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

    public void DisableCheckPoints()
    {
        CheckPoint = GlobalCheckPoint;
        for (int i = 0; i < CheckPoints.Length; i++)
        {
            CheckPoints[i].GetComponent<Animator>().SetBool("Used", false);
            CheckPoints[i].GetComponent<LocalCheckPoint>().Used = false;
        }
    }
}