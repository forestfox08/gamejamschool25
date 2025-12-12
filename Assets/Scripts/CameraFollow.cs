using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Player Settings")]
    public Transform player;             // Sleep je speler hier naartoe in de Inspector
    public float smoothSpeed = 0.125f;   // Hoe vloeiend de camera volgt
    public Vector3 offset = new Vector3(0, 1, -5); // Dichtbij camera positie t.o.v. speler

    private float fixedY; // De vaste Y-positie van de camera

    void Start()
    {
        if (player != null)
            fixedY = transform.position.y; // Zet de Y-positie vast bij starten
    }

    void LateUpdate()
    {
        if (player == null) return;

        // Bereken target X (horizontaal volgen)
        float targetX = player.position.x + offset.x;

        // Vaste Y en Z
        Vector3 targetPosition = new Vector3(targetX, fixedY + offset.y, offset.z);

        // Vloeiend bewegen
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
