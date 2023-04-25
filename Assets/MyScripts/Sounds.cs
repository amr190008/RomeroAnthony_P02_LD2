using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource _keySound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioSource newSound = Instantiate(_keySound, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }

    }
}
