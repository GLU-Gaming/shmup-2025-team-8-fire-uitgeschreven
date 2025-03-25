using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        int newScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(newScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
