using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] float delay = 4f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOver()
    {
            StartCoroutine(DelayGame());
           
    }

    IEnumerator DelayGame()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Game Over");
    }
}
