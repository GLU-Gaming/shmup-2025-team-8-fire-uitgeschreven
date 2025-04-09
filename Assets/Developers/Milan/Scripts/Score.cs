using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int amountScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    private GameObject GameObjectScore;
    void Start()
    {

    }

    void Update()
    {
        scoreText.text = "Score: " + amountScore;
        if (SceneManager.GetActiveScene().name == "Win Screen" || SceneManager.GetActiveScene().name == "Game Over")
        {
            GameObjectScore = GameObject.Find("Score");
            scoreText = GameObjectScore.GetComponent<TextMeshProUGUI>();
            scoreText.text = "Score: " + amountScore;
            Destroy(gameObject);
        }
    }
}
