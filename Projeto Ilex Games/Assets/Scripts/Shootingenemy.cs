using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingenemy : MonoBehaviour
{
    [SerializeField]
    private GameObject Laser;
    [SerializeField]
    private float rateShoot;
    [SerializeField]
    private Transform[] spawnLasers;
    void Start()
    {
        InvokeRepeating("shootingEnemy", rateShoot, rateShoot);
        
    }
    void shootingEnemy()
    {
        for (int i = 0; i < spawnLasers.Length; i++)
        {
            Instantiate(Laser, spawnLasers[i].position, spawnLasers[i].rotation);
        }
    }
    
}
