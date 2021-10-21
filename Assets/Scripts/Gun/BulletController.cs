using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
}
