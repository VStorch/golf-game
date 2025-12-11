using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform spawnPoint;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PlayerRespawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.position = spawnPoint.position;

        // Subir um pouco para não atravessar chão
        transform.position += Vector3.up * 0.2f;
    }
}
