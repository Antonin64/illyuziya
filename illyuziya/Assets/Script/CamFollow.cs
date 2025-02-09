using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform player; // Référence au joueur
    public float minDistance = 15f; // Distance minimale avant d'arrêter de suivre
    public float maxDistance = 100f; // Distance maximale avant d'arrêter de suivre

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            // Regarder le joueur seulement s'il est dans la plage de distance
            if (distance > minDistance && distance < maxDistance)
            {
                transform.LookAt(player);
            }
        }
    }
}
