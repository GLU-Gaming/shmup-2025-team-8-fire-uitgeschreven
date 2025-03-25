using Unity.VisualScripting;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    private GameManager game;
    [SerializeField] private GameObject smallPlayer;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (game.isWaveCleared == true)
        {
            //smallPlayer.transform.position = 
        }
    }
}
