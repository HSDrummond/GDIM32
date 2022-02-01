using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        target = Player.transform;

        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90, 0), Space.Self);

        float DistanceFromPlayer = 3f;
        if (Vector3.Distance(transform.position, target.position) > DistanceFromPlayer)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0 ,0));
        }
    }
}
