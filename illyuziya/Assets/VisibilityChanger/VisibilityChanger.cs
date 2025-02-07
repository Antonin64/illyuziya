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
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
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
    }

    void OnTriggerExit(Collider other)
    {
        overlaps--;
        if (overlaps == 0 && col.isTrigger)
        {
            col.isTrigger = false;
        }
    }
}
