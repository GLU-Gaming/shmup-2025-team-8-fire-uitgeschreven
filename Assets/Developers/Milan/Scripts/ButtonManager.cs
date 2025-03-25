using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private bool isTransitioning = false;
    private float Timer = 1.35f;
    [SerializeField] private Animator anim;
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
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
