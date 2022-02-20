using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
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
