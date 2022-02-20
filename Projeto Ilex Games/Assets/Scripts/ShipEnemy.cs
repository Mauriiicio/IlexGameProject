using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipEnemy : MonoBehaviour
{
    [SerializeField]
    private float ShipDodge;
    [SerializeField]
    private float Speed;
    [SerializeField]
    private Limit limit;
    [SerializeField]
    private Vector2 startMoviment;
    [SerializeField]
    private Vector2 DodgTime;
    [SerializeField]
    private Vector2 DodgWaitTime;

    private Rigidbody2D rgb2D;
    private float NextMark;

    void Start()
    {
        rgb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(movimenteDodge());
    }

    
    private void FixedUpdate()
    {
        float newDodge = Mathf.MoveTowards(rgb2D.velocity.x, NextMark, Speed);
        rgb2D.velocity = new Vector2(newDodge, rgb2D.velocity.y);
        rgb2D.position = new Vector2(Mathf.Clamp(rgb2D.position.x, limit.xLimitMin, limit.xLimitMax),
                                     Mathf.Clamp(rgb2D.position.y, limit.yLimitMin, limit.yLimitMax));
    }
    //Faz com que a nave inimiga mova-se aleatoriamente.
    IEnumerator movimenteDodge()
    {
        yield return new WaitForSeconds(Random.Range(startMoviment.x, startMoviment.y));
        while (true)
        {
            NextMark = Random.Range(1, ShipDodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(DodgTime.x, DodgTime.y));
            NextMark = 0;
            yield return new WaitForSeconds(Random.Range(DodgWaitTime.x, DodgWaitTime.y));
        }
    }
}
