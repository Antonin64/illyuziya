using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    // References to the player's camera, the portal this camera is attached to, and the other portal
    public Transform player_cam;
    public Transform portal;
    public Transform otherPortal;

    // Boolean to determine if the portal's position should be negated
    public bool neg;

    void Start()
    {
        // Initialization code can be placed here if needed
    }

    void LateUpdate()
    {
        // Calculate the offset of the player's camera from the other portal
        Vector3 playerOffsetFromPrtal = player_cam.position - otherPortal.position;

        // If neg is false, set the camera's position to the portal's position plus the player's offset
        if (!neg)
            transform.position = portal.position + playerOffsetFromPrtal;
        // If neg is true, negate the y-axis of the portal's position and the player's offset
        else
            transform.position = new Vector3(portal.position.x, -portal.position.y, portal.position.z) - new Vector3(playerOffsetFromPrtal.x, -playerOffsetFromPrtal.y, playerOffsetFromPrtal.z);

        // Calculate the angular difference between the portal's rotation and the other portal's rotation
        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        // Create a rotation difference quaternion based on the angular difference around the y-axis
        Quaternion portalRotDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);

        // Calculate the new camera direction by applying the rotation difference to the player's camera forward direction
        Vector3 newCamDir = portalRotDiff * player_cam.forward;

        // Set the camera's rotation to look in the new direction with the up vector as the y-axis
        transform.rotation = Quaternion.LookRotation(newCamDir, Vector3.up);

        // The following code is commented out and can be used for an alternative approach
        /*
        Matrix4x4 m = portal.localToWorldMatrix * otherPortal.localToWorldMatrix * player_cam.localToWorldMatrix;
        portal_cam.SetPositionAndRotation(m.GetColumn(3), m.rotation);
        */
    }
}
