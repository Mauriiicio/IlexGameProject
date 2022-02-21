using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //Calculo do Dano e verificacao de colisao.
    [SerializeField]
    private int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Life life = collision.GetComponent<Life>();
        if(life != null)
        {
            life.Damage(damage);
            Destroy(gameObject);

        }
    }
}
