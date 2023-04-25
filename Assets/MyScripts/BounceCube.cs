using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCube : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField] private AudioSource _bounceSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void ReverseGravity()
    {
        rb.AddForce(Vector3.up * 500);

        AudioSource newSound = Instantiate(_bounceSound, transform.position, Quaternion.identity);
        Destroy(newSound.gameObject, newSound.clip.length);

        Debug.Log(" This is being hit ");
    }
}