using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBonuses : MonoBehaviour
{
    public int gearsCount;
    public Text gearText;

    public void start()
    {
        gearText.text = $"Gears: {gearsCount}";
    }

    public void addGear(int value)
    {
        gearsCount += value;
        gearText.text = $"Gears: {gearsCount}";
    }
}
