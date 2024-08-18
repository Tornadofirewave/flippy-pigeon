using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float deadZone = -45f;

    private void Update()
    {
        Move();
        CheckDeadZone();
    }

    private void Move()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    private void CheckDeadZone()
    {
        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted.");
            Destroy(gameObject);
        }
    }
}