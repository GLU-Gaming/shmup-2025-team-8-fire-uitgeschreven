using UnityEngine;

public class Controlsmenu : MonoBehaviour
{
    private GameManager game;
    public bool isControlsOpen = false;
    private void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        isControlsOpen = true;
        game.isGamePaused = true;
    }
    private void Update()
    {

    }
    public void CloseMenu()
    {
        isControlsOpen = false;
        game.isGamePaused = false;
        gameObject.SetActive(false);

    }
}
