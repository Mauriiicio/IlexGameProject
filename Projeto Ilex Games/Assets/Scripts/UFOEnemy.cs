using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemy : MonoBehaviour
{
    [SerializeField]
    private float speedUFO;
    [SerializeField]
    private float SpeedRotation; 

    private Transform player;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

   
    void Update()
    {
        //UFO seguir o player.
        transform.position = Vector2.MoveTowards(transform.position, player.position, speedUFO * Time.deltaTime);
        //UFO girar
        transform.Rotate(new Vector3(0, 0, SpeedRotation) * Time.deltaTime);

    }
   
}
