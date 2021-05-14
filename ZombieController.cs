using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;
    private bool TocoNinja = false;
    public int speed = 1;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TocoNinja)
        {
            sr.flipX = true;
            rb2d.velocity = new Vector2(x: -speed, rb2d.velocity.y);
        }
        else
        {
            TocoNinja = false;
            setAtackAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        TocoNinja = false;

        if (other.gameObject.tag == "ninja")
        {
            TocoNinja = true;
            Debug.Log("TOCO NINJA");
        }
    }

    private void setAtackAnimation()
    {
        _animator.SetInteger("Estado", 1);
    }
}

