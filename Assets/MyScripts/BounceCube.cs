using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCube : MonoBehaviour
{

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void ReverseGravity()
    {
        rb.AddForce(Vector3.up * 500);

        Debug.Log(" This is being hit ");
    }
}