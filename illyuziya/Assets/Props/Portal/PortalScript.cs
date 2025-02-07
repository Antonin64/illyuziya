using UnityEngine;

public class PortalScript : MonoBehaviour
{

    public GameObject portal1;
    public GameObject portal2;

    public RenderTexture renderTexture1;
    public RenderTexture renderTexture2;

    public Camera camera1;
    public Camera camera2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera1.targetTexture = renderTexture1;
        camera2.targetTexture = renderTexture2;

        portal1.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        portal2.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        portal1.GetComponent<Renderer>().material.SetTexture("_BaseMap", renderTexture2);
        portal2.GetComponent<Renderer>().material.SetTexture("_BaseMap", renderTexture1);
    }

    void Awake()
    {
        renderTexture1 = new RenderTexture(Screen.width, Screen.height, 24);
        renderTexture2 = new RenderTexture(Screen.width, Screen.height, 24);
        renderTexture1.Create();
        renderTexture2.Create();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    
}
