using UnityEngine;

public class CubeScaler : MonoBehaviour
{
    public Transform target; // Objet cible (ex: joueur)
    public float scaleFactor = 0.1f; // Facteur d'ajustement de la taille
    public float minScale = 0.5f; // Taille minimale
    public float maxScale = 3.0f; // Taille maximale
    public int OptionSize = 2; // 1 = Grossit, 0 = Rapetisse, 2 = Ne change pas
    private Vector3 initialScale; // Stocke la taille initiale du cube

    void Start()
    {
        initialScale = transform.localScale; // Sauvegarde la taille initiale du cube
    }

    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);
            float newScale = initialScale.x;

            switch (OptionSize)
            {
                case 1: // Grossit en s'approchant
                    newScale = Mathf.Clamp(maxScale - (distance * scaleFactor), minScale, maxScale);
                    break;
                case 0: // Rapetisse en s'approchant
                    newScale = Mathf.Clamp(minScale + (distance * scaleFactor), minScale, maxScale);
                    break;
                case 2: // Garde sa taille initiale
                    newScale = initialScale.x;
                    break;
            }

            transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }

    // Fonction publique pour modifier OptionSize via un bouton ou une plaque de pression
    public void SetOptionSize(int newOption)
    {
        OptionSize = newOption;
    }
}
