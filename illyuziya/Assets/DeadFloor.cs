using UnityEngine;

public class DeadFloor : MonoBehaviour
{
    [SerializeField] GameObject level;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            level.GetComponent<LevelToto>().ResetLevel();
        }
    }
}
