using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject[] enemy;
    public Limit limit;
    public GameObject gameOvertxt;

    [SerializeField]
    private Text Points_txt;

    private int enemyLimit = 10;
    private bool GameOver = false;
    private int enemyNumbers = 1;
    private int points;
    void Start()
    {
        gameManager = this;
        StartCoroutine(SpawnEnemys());
    }

   
    void Update()
    {
        if (GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    //Instanciando os inimigos aleatorios
    //locais aleatorias e de maneira gradativa.
    IEnumerator SpawnEnemys()
    {
        yield return new WaitForSeconds(1f);
        while (!GameOver)
        {
            for (int i = 0; i < enemyNumbers; i++)
            {
                GameObject ActualEnemy = enemy[Random.Range(0, enemy.Length)];
                Vector3 SpawnEnemy = new Vector3(Random.Range(limit.xLimitMin, limit.xLimitMax), limit.yLimitMin, 0);
                Instantiate(ActualEnemy, SpawnEnemy, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(1,4));
            }
            enemyNumbers++;
            if (enemyNumbers >= enemyLimit)
                enemyNumbers = enemyLimit;
            yield return new WaitForSeconds(2f);
        }
    }
    //Contagem dos pontos
    public void Score(int score)
    {
        points += score;
        Points_txt.text = points.ToString();
    }
    public void gameOver()
    {
        GameOver = true;
        gameOvertxt.SetActive(true);
    }
}
