using UnityEngine;

public class PlayerPickDrop : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private float pickUpDistance = 2f;
    [SerializeField] private Transform objectGrabPointTransform;

    public ObjectGrabbable objectGrabbable;

    private Transform playerCameraTransform;
    private void Start()
    {
        playerCameraTransform = cam.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                    }
                }
            } else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabbable != null)
            {
                objectGrabbable.Launch((objectGrabPointTransform.position - cam.transform.position).normalized);
                objectGrabbable = null;
            }
        }
    }
}
