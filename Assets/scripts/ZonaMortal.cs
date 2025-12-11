using UnityEngine;

public class ZonaMortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn rb = other.GetComponent<Respawn>();

            if (rb != null)
                rb.PlayerRespawn();
        }
    }
}
