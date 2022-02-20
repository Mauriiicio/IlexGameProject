using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    //destroy os objeto que estiverem com este script depois de um tempo determinado.
    [SerializeField]
    private float destroytime;
    void Start()
    {
        Destroy(gameObject, destroytime);
    }

   
}
