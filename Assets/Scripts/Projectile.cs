using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float hungerValue;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip throwSound;
    private void Start()
    {
        Destroy(gameObject, 2f);
        audioSource.PlayOneShot(throwSound);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().currentHunger += hungerValue;
            Destroy(gameObject, 0.1f);
        }
    }
}
