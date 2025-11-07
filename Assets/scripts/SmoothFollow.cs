using UnityEngine;

[AddComponentMenu("Camera-Control/Smooth Follow")]
public class SmoothFollow : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target;

    [Header("Follow Settings")]
    public float distance = 10f;
    public float height = 5f;
    public float rotationDamping = 2f;
    public float heightDamping = 2f;

    void LateUpdate()
    {
        if (target == null) return;

        float desiredRotation = target.eulerAngles.y;
        float desiredHeight = target.position.y + height;

        float currentRotation = Mathf.LerpAngle(transform.eulerAngles.y, desiredRotation, rotationDamping * Time.deltaTime);
        float currentHeight = Mathf.Lerp(transform.position.y, desiredHeight, heightDamping * Time.deltaTime);

        Quaternion rotation = Quaternion.Euler(0f, currentRotation, 0f);
        Vector3 newPosition = target.position - rotation * Vector3.forward * distance;
        newPosition.y = currentHeight;

        transform.position = newPosition;
        transform.LookAt(target);
    }
}
