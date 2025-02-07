using UnityEngine;

public class PortalTP : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject portal;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = portal.transform.position;
            other.transform.rotation = portal.transform.rotation;   
        }
    }
}
