using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;

    [Header("Camera Follow")]
    [SerializeField] float smoothening;
    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;

    Vector3 velocity = Vector3.zero;

    private void Update()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - offsetZ;
        pos.y = player.position.y - offsetY;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothening);

    }
}
