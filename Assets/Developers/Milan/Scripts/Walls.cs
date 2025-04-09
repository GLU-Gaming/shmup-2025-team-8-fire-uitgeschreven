using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float offset = -7.4f;
    private GameManager game;

    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }
    void Update()
    {
        if (game.isWaveCleared == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        }
        if (transform.position.x <= offset)
        {
            transform.position = new Vector3(189.1f, -470.4f, 1590.418f);
        }

    }

}
