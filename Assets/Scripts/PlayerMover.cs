using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;

    public AudioClip[] footsteps;
    [SerializeField] private AudioSource moveSound;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSound = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            anim.Play("Tomoko_a_walk");
           Footstep();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            anim.Play("Tomoko_d_walk");
            Footstep();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            anim.Play("Tomoko_w_walk");
           Footstep();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            anim.Play("Tomoko_s_walk");
            Footstep();
        }
    }

    void Footstep()
    {
        int randInt = Random.Range(0, footsteps.Length);

        moveSound.PlayOneShot(footsteps[randInt]);
    }
}
