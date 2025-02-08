using UnityEngine;

public class LevelBehaviour : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    public GameObject player;

    public GameObject globalVolume;

    public int portalpassed = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            portalpassed++;
            //pass to next level if portalpassed is 20
        }
    }
}
