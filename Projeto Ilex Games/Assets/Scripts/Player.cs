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

    private float nextShoot;
    private Rigidbody2D rgb2D;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Limit limit;
    [SerializeField]
    private int shootPower = 1;
    

    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        if (Input.GetKey(KeyCode.Space) && Time.time > nextShoot)
        {
            nextShoot = Time.time + rateShoot;
            if (shootPower >= 1)
            {
                Instantiate(LaserGameObject, spawnsLaser[0].transform.position, spawnsLaser[0].transform.rotation);
            }
            if (shootPower >= 2)
            {
                Instantiate(LaserGameObject, spawnsLaser[1].transform.position, spawnsLaser[1].transform.rotation);
                Instantiate(LaserGameObject, spawnsLaser[2].transform.position, spawnsLaser[2].transform.rotation);
            }
            if (shootPower >= 3)
            {
                Instantiate(LaserGameObject, spawnsLaser[3].transform.position, spawnsLaser[3].transform.rotation);
                Instantiate(LaserGameObject, spawnsLaser[4].transform.position, spawnsLaser[4].transform.rotation);
            }
        }
    }
}
