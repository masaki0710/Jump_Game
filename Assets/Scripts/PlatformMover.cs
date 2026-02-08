using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Vector3 direction = new Vector3(-1, 0, 0);

    void Update()
    {
        transform.Translate(direction.normalized * GameConfig.PlatformMoveSpeed * Time.deltaTime, Space.World);

        if (transform.position.x < -20.0f)
        {
            Destroy(gameObject);
        }
    }
}
