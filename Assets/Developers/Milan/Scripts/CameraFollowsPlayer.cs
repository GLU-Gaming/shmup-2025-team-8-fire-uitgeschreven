using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 cameraMiddle;
    [SerializeField] private Transform player;
    [SerializeField] private Light light;
    private float lightIntensity = 20f;
    
    [SerializeField] float Timer = 3;
    private GameManager game;


    [SerializeField] private GameObject backgroundCubes;
    private PlayerMovement playerMovement;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void FixedUpdate()
    {
        light.intensity = lightIntensity;
        cameraMiddle = transform.position;
        if (game.isWaveCleared == true)
        {
            Timer -= Time.deltaTime;
            lightIntensity -= 0.01f;
            playerMovement.GoDeeper();
            backgroundCubes.transform.position = new Vector3(backgroundCubes.transform.position.x - speed * Time.deltaTime, backgroundCubes.transform.position.y - -speed * Time.deltaTime, backgroundCubes.transform.position.z);
        if (Timer <= 0)
        {
            game.isWaveCleared = false;
                Timer = 3;
                game.StartWave();
                game.maxEnemy += 1;
                game.minEnemy += 1;
            }
            
        }
    }
}
