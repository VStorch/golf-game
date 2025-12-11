using UnityEngine;

public class PararBola : MonoBehaviour
{
    public Rigidbody rb;
    public float minSpeed = 0.05f;
    public float maxRollingTime = 2f;
    private float rollingTimer = 0f;

    void Start()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = rb.velocity.magnitude;

        // Se estiver muito devagar
        if (speed < minSpeed && speed > 0.001f)
        {
            rollingTimer += Time.deltaTime;

            // Se já passou muito tempo rolando devagar -> força parada
            if (rollingTimer >= maxRollingTime)
            {
                StopBall();
            }
        }
        else if (speed >= minSpeed)
        {
            // Se voltou a acelerar, reseta o timer
            rollingTimer = 0f;
        }
        else
        {
            // Está totalmente parada
            rollingTimer = 0f;
        }
    }

    void StopBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rollingTimer = 0f;
    }
}