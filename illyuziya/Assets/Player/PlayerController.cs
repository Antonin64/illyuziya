﻿using UnityEngine;

namespace GoThrough.Samples
{
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerController : MonoBehaviour
    {
        public float speed = 10.0f;
        public float gravity = 10.0f;
        public float maxVelocityChange = 10.0f;
        public float mouseSensitivity = 100.0f;
        public float jumpPower = 7f;
        public new Camera camera;

        private new Rigidbody rigidbody;
        private bool grounded = false;
        private float xRotation = 0.0f;
        private PlayerPickDrop pickDropScript;
        public bool touchPickable = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Picked"))
            {
                pickDropScript.objectGrabbable.Drop();
                pickDropScript.objectGrabbable = null;
            }
            if (collision.gameObject.CompareTag("Pickable"))
            {
                touchPickable = true;
            }
            if (collision.gameObject.CompareTag("Plateform"))
            {
                transform.parent = collision.gameObject.transform;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Pickable"))
            {
                touchPickable = false;
            }
            if (collision.gameObject.CompareTag("Plateform"))
            {
                transform.parent = null;
            }
        }

        void Awake()
        {
            this.rigidbody = this.GetComponent<Rigidbody>();
            this.rigidbody.freezeRotation = true;
            this.rigidbody.useGravity = false;
            pickDropScript = this.GetComponent<PlayerPickDrop>();

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * this.mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * this.mouseSensitivity * Time.deltaTime;

            this.xRotation -= mouseY;
            this.xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            this.camera.transform.localRotation = Quaternion.Euler(this.xRotation, 0.0f, 0.0f);
            this.transform.Rotate(Vector3.up * mouseX, Space.Self);
            this.rigidbody.rotation = this.transform.rotation;

            //Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //targetVelocity = this.transform.TransformDirection(targetVelocity);
            //targetVelocity *= this.speed;

            //this.transform.Translate(targetVelocity * Time.deltaTime, Space.World);

            if (this.grounded && Input.GetButtonDown("Jump") && pickDropScript.objectGrabbable == null)
            {
                this.rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            }
        }

        void FixedUpdate()
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = this.transform.TransformDirection(targetVelocity);
            targetVelocity *= this.speed;


            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = rigidbody.linearVelocity;
            Vector3 velocityChange = this.transform.TransformVector(targetVelocity - velocity);
            //Debug.Log(velocityChange);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;

            this.rigidbody.AddForce(this.transform.InverseTransformVector(velocityChange), ForceMode.VelocityChange);

            // We apply gravity manually for more tuning control
            this.rigidbody.AddRelativeForce(new Vector3(0, -gravity * rigidbody.mass, 0));

            this.grounded = false;
        }

        void OnTriggerStay()
        {
            this.grounded = true;
        }
    }
}
