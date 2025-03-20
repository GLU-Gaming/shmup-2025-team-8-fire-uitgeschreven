using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gulper_Eel;
    [SerializeField] GameObject spawnLocation;
    void Start()
    {
        StartWave();
    }

    private void StartWave()
    {
        Instantiate(gulper_Eel, spawnLocation.transform.position, spawnLocation.transform.rotation);
    }
}
