using UnityEngine;

public class BoxZoneAudio : MonoBehaviour
{
    public AudioSource audioSource; // Référence à l'AudioSource
    public bool stopAudioOnExit = false; // Option : Arrêter l'audio à la sortie de la zone
    public Transform spawnPoint; // Référence au point de spawn (téléportation)

    private void Start()
    {
        if (audioSource == null)
        {
            // Si aucune AudioSource n'est assignée, utilise celle attachée au même GameObject
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui entre dans la zone
        if (other.CompareTag("Player"))
        {
            // Joue l'audio si disponible
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
                Debug.Log("Player est entré dans la zone. Audio lancé !");
            }

            // Téléporte le joueur au point de spawn
            if (spawnPoint != null)
            {
                other.transform.position = spawnPoint.position; // Déplace le joueur au point de spawn
                Debug.Log("Player téléporté au point de spawn.");
            }
            else
            {
                Debug.LogWarning("Aucun point de spawn assigné !");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifie si c'est le joueur qui quitte la zone
        if (other.CompareTag("Player") && stopAudioOnExit)
        {
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop(); // Arrête l'audio
                Debug.Log("Player a quitté la zone. Audio arrêté !");
            }
        }
    }
}
