using UnityEngine;

public class SeaMine : MonoBehaviour
{
    public bool hasExploded;
    [SerializeField] private GameObject seaMineRadius;
    private SphereCollider sphereCollider;
    void Start()
    {
        sphereCollider = seaMineRadius.GetComponent<SphereCollider>();

    }
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
            sphereCollider.enabled = true;
            hasExploded = true;
            Destroy(gameObject);
    }

}
