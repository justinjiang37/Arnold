using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class playerControl : MonoBehaviour {
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

        Vector3 finalVector = new Vector3(horizontalVector.x, 0.0f, verticalVector.x);

        rb.AddForce(finalVector * speed);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit(Collision other) {

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
