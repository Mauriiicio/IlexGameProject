using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BonusPoint : MonoBehaviour {
    [SerializeField]
    private int points;
    private void OnTriggerEnter2D(Collider2D collision) {
        Player player = collision.GetComponent<Player>();
        if (player != null) {
            GameManager.gameManager.Score(points);
            if (GameManager.gameManager.player1.IsDead() && !GameManager.gameManager.player2.IsDead()) {
                GameManager.gameManager.player1.Revive();
            } else if (GameManager.gameManager.player2.IsDead() && !GameManager.gameManager.player1.IsDead()) {
                GameManager.gameManager.player2.Revive();
            }
            Destroy(gameObject);
        }
    }
}
