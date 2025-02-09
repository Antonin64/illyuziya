using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject boxPrefab; // Le prefab du cube à faire spawn
    public Transform spawnPoint; // L'endroit où spawn les cubes
    public float pressDepth = 0.2f; // Profondeur d'enfoncement de la plaque
    public float pressSpeed = 5f; // Vitesse d'enfoncement
    public int maxBoxes = 20; // Nombre max de cubes à faire apparaître
    private int boxCount = 0; // Compteur de cubes spawnés
    private Vector3 initialPosition; // Position de base de la plaque
    private bool isPressed = false; // Vérifie si la plaque est enfoncée

    void Start()
    {
        initialPosition = transform.position; // Stocke la position initiale
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && boxCount < maxBoxes && !isPressed)
        {
            isPressed = true; // Marque la plaque comme enfoncée
            StartCoroutine(PressPlate()); // Lance l'enfoncement

            // Spawn d'un cube
            GameObject newBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
            CubeScaler scaler = newBox.GetComponent<CubeScaler>();
            if (scaler != null)
            {
                scaler.target = other.transform; // Assigne dynamiquement le Player comme cible
            }
            boxCount++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPressed = false; // Marque la plaque comme relâchée
            StartCoroutine(ReleasePlate()); // Remonte la plaque
        }
    }

    System.Collections.IEnumerator PressPlate()
    {
        Vector3 targetPosition = initialPosition - new Vector3(0, pressDepth, 0);
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * pressSpeed);
            yield return null;
        }
    }

    System.Collections.IEnumerator ReleasePlate()
    {
        while (Vector3.Distance(transform.position, initialPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * pressSpeed);
            yield return null;
        }
    }
}
