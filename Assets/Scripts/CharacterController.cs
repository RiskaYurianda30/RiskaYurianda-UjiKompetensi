using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    private Animator animator;


    [SerializeField] private float moveSpeed = 10f;
    
    [Header("Projectile Properties")]
    [SerializeField] private GameObject throwable;
    [SerializeField] private float projectileSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.IsGameOver) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        animator.SetBool("StrafeLeft", Input.GetAxisRaw("Horizontal") < 0);
        animator.SetBool("StrafeRight", Input.GetAxisRaw("Horizontal") > 0);

        rb.velocity = movement * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }

    private void Throw()
    {
        animator.SetTrigger("Throw");
        GameObject projectile = Instantiate(throwable, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileSpeed * Time.deltaTime;
    }
}
