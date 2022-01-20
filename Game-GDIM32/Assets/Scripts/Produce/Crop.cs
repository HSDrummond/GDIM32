using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Crop", menuName = "Card")]
public class Crop : ScriptableObject
{

    public new string name;
    public string description;

    public Sprite artwork;

    public int pointsWorth;
    public bool ableToPickUp;

    public void Print()
    {
        Debug.Log(name + ": " + description + "This crop is worth: " + pointsWorth + " points");
    }
}
