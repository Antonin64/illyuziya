using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    public GameObject player;

    public GameObject globalVolume;

    public int portalpassed = 0;

    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            portalpassed++;
            if (portalpassed == 1) {
                audioSource.Play();
            }
            //pass to next level if portalpassed is 20
        }
    }
}
