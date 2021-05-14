using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KunaiController : MonoBehaviour
{
    public float velocityX = 15f;
    private Rigidbody2D rb;
    private int puntaje = 0;

    public Text PuntajeTexto;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PuntajeTexto.text = "PUNTAJE: " + puntaje;
        rb.velocity = Vector2.right * velocityX;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombie")
        {
            puntaje += 10;
            Debug.Log("PUNTAJE NINJA: " + puntaje);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
