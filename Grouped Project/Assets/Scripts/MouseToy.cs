using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseToy : MonoBehaviour
{
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        audioSource.Play();
    }
}
