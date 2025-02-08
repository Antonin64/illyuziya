using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    [SerializeField] private float launchPower = 10f;
    private bool onPlateform = false;
    private GameObject colPlateform;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }
    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        transform.parent = null;
        tag = "Picked";
    }

    public void Launch(Vector3 direction)
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        tag = "Pickable";
        objectRigidbody.AddForce(direction * launchPower);
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        tag = "Pickable";
        if (onPlateform)
        {
            transform.parent = colPlateform.transform;
            onPlateform = false;
        }
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition =  Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateform"))
        {
            if (!CompareTag("Picked"))
            {
                transform.parent = collision.gameObject.transform;
            } else
            {
                onPlateform = true;
                colPlateform = collision.gameObject;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plateform"))
        {
            transform.parent = null;
        }
    }
}
