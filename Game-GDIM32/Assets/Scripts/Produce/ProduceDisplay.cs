using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceDisplay : MonoBehaviour
{
    public Crop crop;
    public Animal animal;
  
    void Start()
    {
        crop.Print();
        animal.Print();
    }

}
