using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoint : MonoBehaviour
{
    //coletavel que da pontos ao jogador.
    [SerializeField]
    private int points;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null)
        {
            GameManager.gameManager.Score(points);
            Destroy(gameObject);
        }
    }
}
