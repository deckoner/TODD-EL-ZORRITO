using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;

    private bool mirandoDerecha = true;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxColaider;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxColaider = GetComponent<BoxCollider2D>();
    }



    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
        procesarSalto();
    }

 /*   bool estaEnSuelo()
    {
        Physics2D.BoxCast(boxColaider.bounds.center, new Vector2(boxColaider.bounds.size.x, boxColaider.size.y), 0f, Vector2.down,0.2f,);
    }*/


    void procesarSalto()
    {
        //Logica del salto
        //Condicion if:
        /*Si se pulsa la tecla espacio*/ /*y*/ /*Esta en el suelo*/
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    void procesarMovimiento()
    {
        //logica de movimiento lateral
        float inputMovimiento = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y );

        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputMovimiento)
    {
        //Girar al prota cuando cambia de direccion
        
        //Condiciones del if:
        /*Si el personaje mira a la derecha*/ /*y*/ /*quiere moverse a la izquierda*/ /*o*/ /*si el personaje mira a la izquierda*/ /*y*/ /*quiere moverse a la derecha*/
        
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);

        }

    }

}
