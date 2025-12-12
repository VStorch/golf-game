using UnityEngine;

public class RotacaoMoinho : MonoBehaviour
{
    public float velocidade = 100f;

    void Update()
    {
        transform.Rotate(0f, 0f, velocidade * Time.deltaTime);
    }
}