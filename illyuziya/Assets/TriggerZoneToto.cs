using UnityEngine;

public class TriggerZoneToto : MonoBehaviour
{
    [SerializeField] private GameObject wall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
        {
            wall.GetComponent<Renderer>().enabled = false;
            wall.GetComponent<Collider>().enabled = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        wall.GetComponent<Renderer>().enabled = true;
        wall.GetComponent<Collider>().enabled = true;
    }
}
