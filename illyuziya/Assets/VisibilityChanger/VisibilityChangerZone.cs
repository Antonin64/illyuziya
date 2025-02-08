using UnityEngine;

public class VisibilityChangerZone : MonoBehaviour
{
    [SerializeField] private GameObject zone;
    [SerializeField] private GameObject player;
    [SerializeField] private float renderDistance = 10f;
    [SerializeField] private bool visibility = true;
    private Camera cam;
    private Renderer rend;
    private Collider col;
    private Plane[] cameraFrustum;
    private bool visible;
    private bool overlaps = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = player.GetComponentInChildren<Camera>();
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (visibility == false)
        {
            rend.enabled = false;
            col.isTrigger = true;
        }
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
        if (Vector3.Distance(cam.transform.position, transform.position) < renderDistance && zone.GetComponent<Zone_script>().playerIn)
        {
            IsTargetVisible();
        }
        else
        {
            visible = false;
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
                    if (!overlaps)
                        col.isTrigger = false;
                }
                visible = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            overlaps = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (overlaps && rend.enabled == true)
            {
                col.isTrigger = false;
            }
            overlaps = false;
        }
    }
}
