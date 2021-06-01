using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
// using UnityEngine.Classes.Colors;
public class player : MonoBehaviour {
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float gravity = 9.82f;
    [SerializeField]
    private float jumpForce = 3.5f;
    public InputAction Horizontal;
    public InputAction Vertical;
    private Rigidbody rb;
    public SphereCollider sphereCollider2d;

    private bool CanJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider2d = new SphereCollider();
    }

    void Update() {
        Vector2 horizontalVector = Horizontal.ReadValue<Vector2>();
        Vector2 verticalVector = Vertical.ReadValue<Vector2>();
        Vector3 finalVector = new Vector3(horizontalVector.x, 0.0f, 0.0f);

        rb.AddForce(finalVector * speed);

        if (CanJump && Vertical.triggered == true) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "CanJump") {
            CanJump = true;
            Debug.Log(CanJump);
        }
        if (other.gameObject.tag == "PickUp") {
            // other.gameObject.
            Debug.Log("EXPLOSION");
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "CanJump") {
            CanJump = false;
            Debug.Log(CanJump);
        }
    }

    private void OnEnable()
    {
        Horizontal.Enable();
        Vertical.Enable();
    }
    private void OnDisable()
    {
        Horizontal.Disable();
        Vertical.Disable();
    }
}
