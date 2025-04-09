using UnityEngine;
using UnityEngine.UI;

public class CameraFollowsPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector3 cameraMiddle;
    [SerializeField] private Transform player;
    [SerializeField] private Light directionalLight;
    private float lightIntensity = 1f;
    [SerializeField] private Image background;
    [SerializeField] float Timer = 3;
    private GameManager game;


    //[SerializeField] private GameObject backgroundCubes;
    private PlayerMovement playerMovement;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            game.isWaveCleared = true;
        }
    }
#endif

    void FixedUpdate()
    {

        directionalLight.intensity = lightIntensity;
        cameraMiddle = transform.position;
        if (game.isWaveCleared == true)
        {
            Timer -= Time.deltaTime;
            lightIntensity -= 0.002f;
            background.color = new Color(background.color.r - 0.001f, background.color.g - 0.001f, background.color.b - 0.001f, background.color.a);


            playerMovement.GoDeeper();

            //backgroundCubes.transform.position = new Vector3(backgroundCubes.transform.position.x - speed * Time.deltaTime, backgroundCubes.transform.position.y - -speed * Time.deltaTime, backgroundCubes.transform.position.z);
            if (Timer <= 0 && game.hasBossSpawned == false)
            {
                game.isWaveCleared = false;
                Timer = 3;
                game.ResetWaves();
                game.StartWave();
                game.maxEnemy += 1;
                game.minEnemy += 1;
            }

        }
    }
}
