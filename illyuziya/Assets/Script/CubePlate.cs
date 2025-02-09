using UnityEngine;

public class CubePlate : MonoBehaviour
{
    public int newOptionSize = 2; // Nouvelle valeur d'OptionSize
    public Collider detectionZone; // Zone spécifique où la modification s'applique

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est bien le joueur
        {
            // Récupère tous les objets dans la zone
            Collider[] objectsInZone = Physics.OverlapBox(
                detectionZone.bounds.center,
                detectionZone.bounds.extents,
                detectionZone.transform.rotation
            );

            bool cubeFound = false;

            foreach (Collider col in objectsInZone)
            {
                CubeScaler cube = col.GetComponent<CubeScaler>();
                if (cube != null)
                {
                    cube.SetOptionSize(newOptionSize); // Change l'OptionSize
                    cubeFound = true;
                }
            }

            if (cubeFound)
                Debug.Log("OptionSize modifié pour tous les cubes dans la zone !");
            else
                Debug.Log("Aucun cube trouvé dans la zone.");
        }
    }
}
