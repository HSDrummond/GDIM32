using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresDisplay : MonoBehaviour
{
    [SerializeField] Text AnimalCounter;
    [SerializeField] Text CropCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimalCounter.text = "Animals: " + (PlayersStats.p1_animal_count).ToString();
        CropCounter.text = "Crops: " + (PlayersStats.p1_crop_count).ToString();
    }
}
