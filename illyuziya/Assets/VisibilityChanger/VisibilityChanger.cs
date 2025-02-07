using UnityEngine;

public class VisibilityChanger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Camera cam;
    private Renderer rend;
    private Collider col;
    private Plane[] cameraFrustum;
    private bool visible;
    private int overlaps = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = player.GetComponentInChildren<Camera>();
        col = GetComponentInChildren<Collider>();
        rend = GetComponentInChildren<Renderer>();
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, col.bounds))
        {
            visible = true;
        }
        else
        {
            visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsTargetVisible();
        if (col.isTrigger)
        {
            
        }
    }

    void IsTargetVisible()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, col.bounds))
        {
            if (!visible)
            {
                visible = true;
            }
        } else
        {
            if (visible)
            {
                if (rend.enabled == true)
                {
                    rend.enabled = false;
                    col.isTrigger = true;
                } else
                {
                    rend.enabled = true;
                    if (overlaps == 0)
                        col.isTrigger = false;
                }
                visible = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        overlaps++;
        Debug.Log("caca");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("pipi");
        overlaps--;
        if (overlaps == 0 && col.isTrigger)
        {
            col.isTrigger = false;
        }
    }
}
