using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    [SerializeField]
    private float speedLaser;

    private Rigidbody2D rgb2D;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        rgb2D.velocity = Vector2.up * speedLaser;
    }

   
    void Update()
    {
        
    }
}
