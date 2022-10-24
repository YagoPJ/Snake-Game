using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject cobraHead;
    public GameObject menuPanelStart, gameOverPanel;
    private bool start; //se o jogo ta jogando ou nao
    public CriarComida criarComida;
    public Text scoreGame;
    public Text scoreGameOver;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        start = false;
        menuPanelStart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && start == false)
        {
            StartGame();
        }

        scoreGame.text = "Score: " + score.ToString();
    }

    public void StartGame()
    {
        criarComida.StartComida();
        score = 0;
        scoreGame.text = "Score: 0";
        start = true;
        Instantiate(cobraHead, new Vector2(0f, 0f), Quaternion.identity);
        menuPanelStart.SetActive(false);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Invoke("RestartGame", 5f);
        scoreGameOver.text = "Score: " + score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void IncScore()
    {
        score += 10;
    }
}
