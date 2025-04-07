using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int amountScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Start()
    {

    }

    void Update()
    {
        scoreText.text = "Score: " + amountScore;
    }
}
