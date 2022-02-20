using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe para fazer os limites que o personagem e os inimigos podem ir.
[System.Serializable]
public class Limit
{
    public float xLimitMin,
                 xLimitMax,
                 yLimitMin,
                 yLimitMax;
}

public class Player : MonoBehaviour
{
    public GameObject LaserGameObject;
    public GameObject[] spawnsLaser;
    public float rateShoot;
    public SpriteRenderer spritePlayer;
    public SpriteRenderer spriteFire;


    private int life = 1;
    private bool Dead = false;
    private float nextShoot;
    private Rigidbody2D rgb2D;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Limit limit;
    
    

    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        shooting();
    }
    private void FixedUpdate()
    {
        movementPlayer();

    }

    //movimento do player e limite da tela.
    public void movementPlayer()
    {
       
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rgb2D.velocity = movement * speed;

            rgb2D.position = new Vector2(Mathf.Clamp(rgb2D.position.x, limit.xLimitMin, limit.xLimitMax),
                                         Mathf.Clamp(rgb2D.position.y, limit.yLimitMin, limit.yLimitMax));
        
    }
    //tiro do player
    //ajustado o tempo do tiro
    public void shooting()
    {
        if (!Dead)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextShoot)
            {
                nextShoot = Time.time + rateShoot;
                Instantiate(LaserGameObject, spawnsLaser[0].transform.position, spawnsLaser[0].transform.rotation);
                
                
            }
        }
    }
    //verificação se esta vivo ou morto para fazer respawn
    public void respawn()
    {
        life--;
        if(life <= 0)
        {
            life = 0;
            Dead = true;
            spritePlayer.enabled = false;
            spriteFire.enabled = false;
            GameManager.gameManager.gameOver();
        }
        
    }
      
}
