using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public GameObject[] enemy;
    public GameObject PointBonus;
    public Limit limit;
    public GameObject gameOvertxt;

    [SerializeField]
    private TextMeshProUGUI Points_txt;

    private int enemyLimit = 10;
    private bool GameOver = false;
    private int enemyNumbers = 1;
    private int points;
    public TextMeshProUGUI playerNameText; 

    void Start()
    {
        gameManager = this;
        string playerName = PlayerPrefs.GetString("PlayerName", "AAA"); 
        playerNameText.text = "Player: " + playerName;
        StartCoroutine(SpawnEnemys());
        StartCoroutine(SpawnPoint());
        Cursor.visible = false;
    }

    void Update()
    {
        if (GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Start"))
            {
                SceneManager.LoadScene("Menu");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Select"))
        {
            Application.Quit();
        }
    }

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
                yield return new WaitForSeconds(Random.Range(1, 4));
            }
            enemyNumbers++;
            if (enemyNumbers >= enemyLimit)
                enemyNumbers = enemyLimit;
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator SpawnPoint()
    {
        yield return new WaitForSeconds(1f);
        while (!GameOver)
        {
            for (int i = 0; i < enemyNumbers; i++)
            {
                Vector3 SpawnPointbonus = new Vector3(Random.Range(limit.xLimitMin, limit.xLimitMax), limit.yLimitMin, 0);
                Instantiate(PointBonus, SpawnPointbonus, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(3, 10));
            }
            enemyNumbers++;
            yield return new WaitForSeconds(3f);
        }
    }

    public void Score(int score)
    {
        points += score;
        Points_txt.text = points.ToString();
    }

    public void gameOver()
    {
        GameOver = true;
        gameOvertxt.SetActive(true);

        // Salva a pontuacao do jogador ao terminar o jogo
        string playerName = PlayerPrefs.GetString("PlayerName", "AAA");
        HighScoreManager.SaveScore(playerName, points);
    }
}
