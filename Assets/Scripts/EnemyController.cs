using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float enemyScoreValue;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Slider slider;
    [SerializeField] private float hungerNeed;
    [SerializeField] private AudioClip destroyAnimalClip;
    [SerializeField] private AudioClip eatClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject particleDead;

    [HideInInspector]
    public float currentHunger;

    void Start()
    {
        slider.maxValue = hungerNeed;
        currentHunger = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentHunger;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if(currentHunger >= hungerNeed)
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            audioSource.PlayOneShot(eatClip);
        }
    }

    private void Dead()
    {
        Instantiate(particleDead, transform.position, Quaternion.identity);
        audioSource.PlayOneShot(destroyAnimalClip);
        Score.GameScore += enemyScoreValue;
        Destroy(gameObject);
    }
}
