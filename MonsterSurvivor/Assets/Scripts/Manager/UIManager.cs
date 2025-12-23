using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject optionsScreen;
    [SerializeField] private GameObject levelUpScreen;
    private void Start()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        optionsScreen.SetActive(false);
        levelUpScreen.SetActive(false);
    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
    public void Pause()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }
    public void Options()
    {
        optionsScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void Back()
    {
        optionsScreen.SetActive(false);
        if(pauseScreen != null)
        {
            pauseScreen.SetActive(true);
        } 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
