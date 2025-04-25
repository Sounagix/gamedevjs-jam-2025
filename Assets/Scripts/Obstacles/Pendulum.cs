using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField]
    private float swingAngle = 30f; // Maximum swing angle
    [SerializeField]
    private float swingSpeed = 1f;  // Speed of the swinging
    [SerializeField]
    private float swingFrequency = 1f; // Frequency of the swing motion

    private float currentAngle;
    private float time;

    void Start()
    {
        // Ensure the rod is set at the initial position
        currentAngle = 0f;
        time = 0f;
    }

    void Update()
    {
        // Update the time based on swing speed
        time += Time.deltaTime * swingSpeed;

        // Calculate the current angle using a sine wave for smooth oscillation
        currentAngle = swingAngle * Mathf.Sin(time * swingFrequency);

        // Apply rotation
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
}

