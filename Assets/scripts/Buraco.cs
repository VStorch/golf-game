using UnityEngine;

public class Buraco : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.gm.FinalizarBuraco();
        }
    }
}
