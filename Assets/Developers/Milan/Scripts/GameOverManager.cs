using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    private Image background;
    private Color depth;
    void Start()
    {
        background = GameObject.Find("Background").GetComponent<Image>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        depth = background.color;
        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            background = GameObject.Find("Background").GetComponent<Image>();
            background.color = depth;
        }
    }
}
