using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator _animator;
    private Rigidbody2D rb2d;

    private bool puedoSaltar = false;
    private bool puedoSubir = false;
    public float upSpeed = 20;
    public float speed = 10;
    private int morir = 10;

    public GameObject kunai;
    public Text VidasTexto;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        VidasTexto.text = "VIDAS: " + morir;

        //KUNAI
        if (Input.GetKeyDown(KeyCode.A))
        {
                var position = new Vector2(transform.position.x + 1.5f, transform.position.y - 0.5f);
                Instantiate(kunai, position, kunai.transform.rotation);
        }


        //CORRER DERECHA
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            setRunAnimation();
            rb2d.velocity = new Vector2(x: 5, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            setIdleAnimation();
        }

        //CORRER IZQUIERDA
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            setRunAnimation();
            rb2d.velocity = new Vector2(x: -5, rb2d.velocity.y);
        }

        //SALTAR
        if (Input.GetKeyDown(KeyCode.UpArrow) && puedoSaltar)
        {
            setJumpAnimation();
            float upSpeed = 35;
            rb2d.velocity = Vector2.up * upSpeed;
        }

        //SUBIR ESCALERA
        if (Input.GetKey(KeyCode.W) && puedoSubir)
        {
            setClimbAnimation();
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        }

        //SLIDE RIGTH
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                sr.flipX = false;
                setSlideAnimation();
                rb2d.velocity = new Vector2(x: 5, rb2d.velocity.y);
            }
        }
        //SLIDE RIGTH
        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                sr.flipX = true;
                setSlideAnimation();
                rb2d.velocity = new Vector2(x: -5, rb2d.velocity.y);
            }
        }

        //glide
        if (Input.GetKeyDown(KeyCode.P))
        {
            setGlideAnimation();
        }

        if (Input.GetKey(KeyCode.P))
        {
            if (Input.GetKey(KeyCode.W))
            {
                setGlideAnimation();
            }
        }

        //MORIR
        if (morir != 10)
        {
            setDeadAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        puedoSaltar = true;

        if (other.gameObject.tag == "piso1")
        {
            Debug.Log("TOCO PISO 1");
        }
        if (other.gameObject.tag == "piso2")
        {
            Debug.Log("TOCO PISO 2");
        }

        morir = 10;

        if (other.gameObject.tag == "zombie")
        {
            morir --;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        puedoSubir = false;
        if (other.gameObject.tag == "stair")
        {
            puedoSubir = true;
        }

    }


    private void setIdleAnimation()
    {
        _animator.SetInteger("Estado", 0);
    }
    private void setRunAnimation()
    {
        _animator.SetInteger("Estado", 1);
    }
    private void setJumpAnimation()
    {
        _animator.SetInteger("Estado", 2);
    }
    private void setSlideAnimation()
    {
        _animator.SetInteger("Estado", 3);
    }
    private void setGlideAnimation()
    {
        _animator.SetInteger("Estado", 4);
    }
    private void setClimbAnimation()
    {
        _animator.SetInteger("Estado", 5);
    }
    private void setAtackAnimation()
    {
        _animator.SetInteger("Estado", 6);
    }
    private void setDeadAnimation()
    {
        _animator.SetInteger("Estado", 7);
    }

}
