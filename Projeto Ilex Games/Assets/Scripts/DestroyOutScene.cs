using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutScene : MonoBehaviour
{
    //destroy objetos fora da tela.
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
