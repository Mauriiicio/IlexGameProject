using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{


    [SerializeField]
    private int health;
    [SerializeField]
    private int points;

    private bool Dead = false;
    


    public GameObject ExplosionAnimation;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    //Tirando vida e verificando a morte
    public void Damage(int damage)
    {
        if (!Dead)
        {
            health -= damage;
            if(health <= 0)
            {
                Instantiate(ExplosionAnimation, transform.position, transform.rotation);
                //verificação se é o player, o player nao deve ser destruido.
                //respawn do player
                if(this.GetComponent<Player>() != null)
                {
                    GetComponent<Player>().respawn();
                }
                else
                {
                    Dead = true;
                    GameManager.gameManager.Score(points);
                    Destroy(gameObject);
                }
            }
        }
    }
}
