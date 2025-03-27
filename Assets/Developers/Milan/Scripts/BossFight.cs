using System.Net.Http.Headers;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] private GameObject miniPlayer;
    private GameManager game;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        //if(miniPlayer.transform.position.y == -213.5535f)
        
    }
}
