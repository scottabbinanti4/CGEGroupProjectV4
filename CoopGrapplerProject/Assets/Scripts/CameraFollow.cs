using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform[] players;
    public float smoothTime = 0.3f;
    public Vector2 offset = new Vector2(2f, 2f);

    private Vector3 velocity;

    void Update()
    {
        if (players.Length == 0)
            return;

        // Calculate the center point between players
        Vector3 centerPoint = GetCenterPoint();

        // Set the camera position smoothly
        Vector3 targetPosition = new Vector3(centerPoint.x + offset.x, centerPoint.y + offset.y, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    Vector3 GetCenterPoint()
    {
        if (players.Length == 1)
            return players[0].position;

        Bounds bounds = new Bounds(players[0].position, Vector3.zero);

        foreach (Transform player in players)
        {
            bounds.Encapsulate(player.position);
        }

        return bounds.center;
    }
}
