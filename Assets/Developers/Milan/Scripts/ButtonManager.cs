using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private bool isTransitioning = false;
    private float Timer = 1.35f;
    [SerializeField] private Animator anim;
    private GameManager game;

    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void StartGameAnim()
    {
        anim.Play("Start");
        isTransitioning = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }
    public void ResumeGame()
    {
        game.isGamePaused = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Update()
    {
        if (isTransitioning == true)
        {

            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                isTransitioning = false;
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
