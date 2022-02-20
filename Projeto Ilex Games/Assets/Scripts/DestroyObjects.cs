using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    [SerializeField]
    private float destroytime;
    void Start()
    {
        Destroy(gameObject, destroytime);
    }

   
}
