using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MovingPlateform : MonoBehaviour
{
    private bool move = false;
    [SerializeField] private Vector3 destination;
    [SerializeField] private float speed = 2f;
    private Vector3 initialPos;
    private bool arrived = false;

    private void Start()
    {
        initialPos = transform.position;
    }
    void Update()
    {
        if (transform.position.x + initialPos.x > destination.x + initialPos.x)
        {
            arrived = true;
        }
        if (arrived == false && move)
        {
            transform.position += speed * Time.deltaTime * destination.normalized;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && move == false && arrived == false)
        {
            move = true;
        }
    }
}
