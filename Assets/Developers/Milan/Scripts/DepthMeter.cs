using Unity.VisualScripting;
using UnityEngine;

public class DepthMeter : MonoBehaviour
{
    private GameManager game;
    [SerializeField] private GameObject smallPlayer;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        GoDeeper();
    }

    //private void GoDeeper()
    //{
    //    //if (game.isWaveCleared == true)
    //    //{
    //        smallPlayer.transform.position = Vector3.MoveTowards(smallPlayer.transform.position,  new Vector3(smallPlayer.transform.position.x, smallPlayer.transform.position.y - 0.5f, smallPlayer.transform.position.z), 1);
    //    //}
       

        private void GoDeeper()
    {
        smallPlayer.transform.position = Vector3.MoveTowards(
            smallPlayer.transform.position,
            new Vector3(smallPlayer.transform.position.x, smallPlayer.transform.position.y - 0.5f, smallPlayer.transform.position.z),
            0.2f
        );
    }
    }
//}
