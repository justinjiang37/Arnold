using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class playerControl : MonoBehaviour {
    [SerializeField]
    private float speed = 5f;
    public InputAction Horizontal;
    public InputAction Vertical;
    private Rigidbody rb;
    public CapsuleCollider capsuleCollider2d;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider2d = new CapsuleCollider();
    }

    void Update() {
        Vector2 horizontalVector = Horizontal.ReadValue<Vector2>();
        Vector2 verticalVector = Vertical.ReadValue<Vector2>();

        Vector3 finalVector = new Vector3(horizontalVector.x, 0.0f, verticalVector.x);

        rb.AddForce(finalVector * speed);
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
