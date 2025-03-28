using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private GameObject spotLight;
    [SerializeField] private Light Light;
    [SerializeField] private Material background;
    void Start()
    {
        
    }

    void Update()
    {
        if (Light.intensity <= 0f)
        {
            spotLight.SetActive(true);
            background.color = Color.white;
        }
        else
        {
            spotLight.SetActive(false);
            background.color = Color.blue;
        }
    }
}
