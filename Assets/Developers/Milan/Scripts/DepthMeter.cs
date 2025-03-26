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

    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (game.isWaveCleared == true)
        {
            smallPlayer.transform.rotation = Quaternion.Slerp(smallPlayer.transform.rotation, Quaternion.Euler(0, 0, -90), 0.3f);
            smallPlayer.transform.position = new Vector3(smallPlayer.transform.position.x, smallPlayer.transform.position.y - 0.0065f, smallPlayer.transform.position.z);
        }
        else
        {
            smallPlayer.transform.rotation = Quaternion.Slerp(smallPlayer.transform.rotation, Quaternion.Euler(0, 0, 0), 0.3f);
        }
    }
}
