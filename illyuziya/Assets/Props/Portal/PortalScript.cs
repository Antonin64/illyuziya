using Unity.VisualScripting;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject portal1;
    public GameObject portal2;

    public Transform playerCamera;

    public RenderTexture renderTexture1;
    public RenderTexture renderTexture2;

    public Camera camera1;
    public Camera camera2;


    bool neg = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        int portal1Layer = LayerMask.NameToLayer("Portal1");
        int portal2Layer = LayerMask.NameToLayer("Portal2");

        portal1.layer = portal1Layer;
        portal2.layer = portal2Layer;

        camera1.cullingMask = ~(1 << portal2Layer);
        camera2.cullingMask = ~(1 << portal1Layer);

        camera1.targetTexture = renderTexture1;
        camera2.targetTexture = renderTexture2;

        portal1.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);
        portal2.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0);

        portal1.GetComponent<Renderer>().material.SetTexture("_BaseMap", renderTexture1);
        portal2.GetComponent<Renderer>().material.SetTexture("_BaseMap", renderTexture2);
        
    }

    void LateUpdate()
    {
        updateCameraPos(camera1, portal1, portal2);
        updateCameraPos(camera2, portal2, portal1);
    }

    void updateCameraPos(Camera camera, GameObject portal, GameObject otherPortal)
    {
        // Calculate the player's position relative to the portal
        Vector3 playerOffsetFromPortal = playerCamera.position - portal.transform.position;

        //Debug.Log("playerdist: " + playerOffsetFromPortal.magnitude);
        // Position the camera relative to the other portal
        camera.transform.position = otherPortal.transform.position + playerOffsetFromPortal;


        // Calculate the player's rotation relative to the portal
        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.transform.rotation, otherPortal.transform.rotation);
        Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
        Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
        camera.transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }

    void Awake()
    {
        renderTexture1 = new RenderTexture(Screen.width, Screen.height, 24);
        renderTexture2 = new RenderTexture(Screen.width, Screen.height, 24);
        renderTexture1.Create();
        renderTexture2.Create();
    }
}
