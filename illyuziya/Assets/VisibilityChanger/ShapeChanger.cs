using GoThrough.Samples;
using UnityEngine;

public class ShapeChanger : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private GameObject player;
    [SerializeField] private float renderDistance = 10f;
    private int index;
    private Camera cam;
    private Collider col;
    private Plane[] cameraFrustum;
    private bool visible;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        index = 0;
        var obj = Instantiate(objects[0]);
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
        cam = player.GetComponentInChildren<Camera>();
        col = obj.GetComponent<Collider>();
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
        if (Vector3.Distance(cam.transform.position, transform.GetChild(0).transform.position) < renderDistance && !player.GetComponent<PlayerController>().touchPickable)  
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
                index++;
                if (index >= objects.Length)
                {
                    index = 0;
                }
                Vector3 posObj = transform.GetChild(0).transform.position;
                Destroy(transform.GetChild(0).gameObject);
                var obj = Instantiate(objects[index]);
                col = obj.GetComponent<Collider>();
                obj.transform.position = posObj;
                obj.transform.parent = transform;
                visible = false;
            }
        }
    }
}
