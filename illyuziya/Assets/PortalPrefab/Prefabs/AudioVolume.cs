using UnityEngine;

public class AudioVolume : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public AudioClip audioClip;
    private AudioSource audioSource;

    private bool played = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (played)
        {
            return;
        }
        if (other.tag == "Player")
        {
            audioSource.Play();
            played = true;
        }
    }
}
