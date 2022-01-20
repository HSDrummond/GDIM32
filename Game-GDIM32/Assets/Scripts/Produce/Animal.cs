using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Animal", menuName = "Animal")]
public class Animal : ScriptableObject
{

    public new string name;
    public string description;

    public Sprite artwork;

    public int pointsWorth;
    public int speed;
    public bool inWater;

    public void Print()
    {
        Debug.Log(name + ": " + description + "This animal is worth: " + pointsWorth + " points");
    }
}
