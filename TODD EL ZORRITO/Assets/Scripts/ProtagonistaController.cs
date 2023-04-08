using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaController : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaGolpe;


    private bool mirandoDerecha = true;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxColaider;
    public LayerMask CapaSuelo;

    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxColaider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {
        procesarMovimiento();
        procesarSalto();
    }

    bool estaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxColaider.bounds.center, new Vector2(boxColaider.bounds.size.x, boxColaider.size.y), 0f, Vector2.down, 0.2f, CapaSuelo);
        return raycastHit.collider != null;
    }


    void procesarSalto()
    {
        //Logica del salto
        //Condicion if:
        /*Si se pulsa la tecla espacio*/ /*y*/ /*Esta en el suelo*/
        if (Input.GetKeyDown(KeyCode.Space) && estaEnSuelo())
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    void procesarMovimiento()
    {
        //logica de movimiento lateral
        float inputMovimiento = Input.GetAxis("Horizontal");

        //condicion if:
        //Si esta en moviento
        if(inputMovimiento != 0f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

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
