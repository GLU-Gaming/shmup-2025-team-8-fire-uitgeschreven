using UnityEngine;

public class Controlsmenu : MonoBehaviour
{
    private GameManager game;
    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        game.isGamePaused = true;
    }
    private void Update()
    {
        game.pauseMenu.SetActive(false);
    }
    public void CloseMenu()
    {
        game.isGamePaused = false;
        gameObject.SetActive(false);

    }
}
