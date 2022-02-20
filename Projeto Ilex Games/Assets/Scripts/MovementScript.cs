using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    //faz o movimento dos objetos em cena.
    [SerializeField]
    private float speed;

    private Rigidbody2D rgb2D;
    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        rgb2D.velocity = transform.up * speed;
    }

   
 
}
