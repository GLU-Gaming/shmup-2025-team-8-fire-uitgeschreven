using UnityEngine;

public class Controlsmenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
