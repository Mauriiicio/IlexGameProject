using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;
    public RectTransform selector;

    private int currentLetterIndex = 0;
    private char[] playerName;
    private char currentLetter = 'A';
    public TextMeshProUGUI highScoresText;

    private float changeRate = 0.2f;
    private float lastChangeTime = 0f;
    private float[] charWidths;

    void Start()
    {
        
        string savedName = PlayerPrefs.GetString("PlayerName", "AAAAA");
        playerName = savedName.ToCharArray(); 

        UpdatePlayerNameText(); 
        DisplayHighScores(); 

        CalculateCharWidths(); 
        UpdateSelectorPosition(); 
        Cursor.visible = false; 
    }

    void Update()
    {
        ControllerSelector();
    }
    public void ControllerSelector()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // Verifica se o tempo decorrido desde a ultima mudanda e maior que o intervalo definido
        if (Time.time - lastChangeTime >= changeRate)
        {
            if (verticalInput > 0)
            {
                ChangeLetter(1);
                lastChangeTime = Time.time;
            }
            else if (verticalInput < 0)
            {
                ChangeLetter(-1);
                lastChangeTime = Time.time;
            }
            else if (horizontalInput > 0)
            {
                MoveToNextLetter();
                lastChangeTime = Time.time;
                UpdateSelectorPosition();
            }
            else if (horizontalInput < 0)
            {
                MoveToPreviousLetter();
                lastChangeTime = Time.time;
                UpdateSelectorPosition();
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("R1"))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("R2"))
        {
            Application.Quit();
        }
    }

    void ChangeLetter(int change)
    {
        currentLetter = playerName[currentLetterIndex];
        currentLetter = (char)(((currentLetter - 'A' + change + 26) % 26) + 'A');
        playerName[currentLetterIndex] = currentLetter;
        UpdatePlayerNameText();
    }

    void MoveToNextLetter()
    {
        currentLetterIndex = (currentLetterIndex + 1) % playerName.Length;
    }

    void MoveToPreviousLetter()
    {
        currentLetterIndex = (currentLetterIndex - 1 + playerName.Length) % playerName.Length;
    }

    void UpdatePlayerNameText()
    {
        playerNameText.text = new string(playerName);
    }

    // Atualiza a posi��o do seletor com base na largura dos caracteres
    void UpdateSelectorPosition()
    {
        float selectorXPosition = 0f;
        for (int i = 0; i < currentLetterIndex; i++)
        {
            selectorXPosition += charWidths[i];
        }
        selector.anchoredPosition = new Vector2(selectorXPosition - (playerNameText.rectTransform.rect.width / 2) + (charWidths[currentLetterIndex] / 2), selector.anchoredPosition.y);
    }

    // Inicializa o array de larguras de caracteres
    void CalculateCharWidths()
    {
        charWidths = new float[playerName.Length];


        TextMeshProUGUI tempText = Instantiate(playerNameText, playerNameText.transform.parent);
        tempText.fontSize = playerNameText.fontSize;

        for (int i = 0; i < playerName.Length; i++)
        {
            tempText.text = playerName[i].ToString();
            charWidths[i] = tempText.preferredWidth;
        }

        Destroy(tempText.gameObject);
    }

    void StartGame()
    {

        PlayerPrefs.SetString("PlayerName", new string(playerName));

        SceneManager.LoadScene("SampleScene");
    }

    void DisplayHighScores()
    {
        List<HighScore> highScores = HighScoreManager.LoadHighScores();
        highScoresText.text = "Top 10 Pilotos:\n";
        for (int i = 0; i < highScores.Count; i++)
        {
            highScoresText.text += (i + 1) + ". " + highScores[i].name + " - " + highScores[i].score + "\n";
        }
    }
}
