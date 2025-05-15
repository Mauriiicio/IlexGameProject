using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe para fazer os limites que o personagem e os inimigos podem ir.
[System.Serializable]
public class Limit {
    public float xLimitMin,
                 xLimitMax,
                 yLimitMin,
                 yLimitMax;
}

public class Player : MonoBehaviour {
    public GameObject LaserGameObject;
    public GameObject[] spawnsLaser;
    public float rateShoot;
    public SpriteRenderer spritePlayer;
    public SpriteRenderer spriteFire;
    public int playerID;


    private int life = 1;
    private bool Dead = false;
    private float nextShoot;
    private Rigidbody2D rgb2D;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Limit limit;



    void Start() {
        rgb2D = GetComponent<Rigidbody2D>();
        Cursor.visible = false;
    }


    void Update() {
        Shooting();
    }
    private void FixedUpdate() {
        MovementPlayer();

    }


    public void MovementPlayer() {
        if (playerID == 1) {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rgb2D.velocity = movement * speed;

            rgb2D.position = new Vector2(Mathf.Clamp(rgb2D.position.x, limit.xLimitMin, limit.xLimitMax),
                                         Mathf.Clamp(rgb2D.position.y, limit.yLimitMin, limit.yLimitMax));
        }
        if (playerID == 2) {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
            rgb2D.velocity = movement * speed;

            rgb2D.position = new Vector2(Mathf.Clamp(rgb2D.position.x, limit.xLimitMin, limit.xLimitMax),
                                         Mathf.Clamp(rgb2D.position.y, limit.yLimitMin, limit.yLimitMax));
        }
    }

    public void Shooting() {
        if (!Dead) {
            if (playerID == 1) {
                if (Input.GetKey("joystick 3 button 0") && Time.time > nextShoot) {
                    nextShoot = Time.time + rateShoot;
                    Instantiate(LaserGameObject, spawnsLaser[0].transform.position, spawnsLaser[0].transform.rotation);
                    Debug.Log("Joystick 1");
                }
            }
            if (playerID == 2) {
                if (Input.GetKey("joystick 2 button 0") && Time.time > nextShoot) {
                    nextShoot = Time.time + rateShoot;
                    Instantiate(LaserGameObject, spawnsLaser[0].transform.position, spawnsLaser[0].transform.rotation);
                    Debug.Log("Joystick 2");
                }
            }
        }
    }

    public void Respawn() {
        life--;
        if (life <= 0) {
            life = 0;
            Dead = true;
            spritePlayer.enabled = false;
            spriteFire.enabled = false;
            GameManager.gameManager.gameOver();

        }

    }

}
