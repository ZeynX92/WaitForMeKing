using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BreakPlatform : MonoBehaviour
{
    public GameObject platform; // ��������� ���������� ���������
    bool canbreak; // ����� �� ���������
    void Start()
    {
        canbreak = true;
    }
    void OnTriggerEnter2D(Collider2D col) // ���� �������� �������� (������ �����)
    {
        Debug.Log(col.tag);
        if (col.tag == "Player" & canbreak)
        {
            Debug.Log("eeee");
            canbreak = false;
            Invoke("Break", 3f);
        }
    }
    void Break()
    {
        platform.SetActive(false);
        Invoke("Regen", 5f);
    }
    void Regen()
    {
        platform.SetActive(true);
        canbreak = true;
    }
}
