using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {
    public static GameManager gameManager;
    public GameObject[] enemy;
    public GameObject PointBonus;
    public Limit limit;
    public GameObject gameOvertxt;
    public Player player1; // Reference to Player 1
    public Player player2; // Reference to Player 2

    [SerializeField]
    private TextMeshProUGUI Points_txt;

    private int enemyLimit = 10;
    private bool gameOver = false;
    private int enemyNumbers = 1;
    private int points;
    public TextMeshProUGUI playerNameText;

    void Start() {
        gameManager = this;
        string playerName = PlayerPrefs.GetString("PlayerName", "AAA");
        playerNameText.text = "Player: " + playerName;
        StartCoroutine(SpawnEnemys());
        StartCoroutine(SpawnPoint());
        Cursor.visible = false;
    }

    void Update() {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            Application.Quit();
        }
    }

    IEnumerator SpawnEnemys() {
        yield return new WaitForSeconds(1f);
        while (!gameOver) {
            for (int i = 0; i < enemyNumbers; i++) {
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

    IEnumerator SpawnPoint() {
        yield return new WaitForSeconds(1f);
        while (!gameOver) {
            for (int i = 0; i < enemyNumbers; i++) {
                Vector3 SpawnPointbonus = new Vector3(Random.Range(limit.xLimitMin, limit.xLimitMax), limit.yLimitMin, 0);
                Instantiate(PointBonus, SpawnPointbonus, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(3, 10));
            }
            enemyNumbers++;
            yield return new WaitForSeconds(3f);
        }
    }

    public void Score(int score) {
        points += score;
        Points_txt.text = points.ToString();


    }

    public void CheckGameOver() {
        if (player1.IsDead() && player2.IsDead()) {
            gameOver = true;
            gameOvertxt.SetActive(true);

            // Save the player's score
            string playerName = PlayerPrefs.GetString("PlayerName", "AAA");
            HighScoreManager.SaveScore(playerName, points);
        }
    }
}