using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProtagonistaController : MonoBehaviour 
{
    public float velocidad;
    public float fuerzaSalto;
    public float fuerzaGolpe;
    private int countWeapon;
    private bool muerto;
    private bool victoria;
    public int cantEnemigos;

    private bool mirandoDerecha = true;
    private Rigidbody2D RB;
    private BoxCollider2D boxColaider;
    public LayerMask CapaSuelo;

    private Animator animator;

    public AudioManager audioManager;
    public AudioClip sonidoSalto;


    

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        boxColaider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        muerto = false;
        victoria = false;
       
    }



    // Update is called once per frame
    void Update()
    {
        if(!muerto && !victoria)
        {
            procesarMovimiento();
            procesarSalto();
        }
        else
        {
            animator.SetBool("isRunning", false);
            velocidad = 0;
        }
        
    }

    bool estaEnSuelo()
    {
        //Devuelve si esta en el suelo
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
            RB.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            audioManager.ReproducirSonido(sonidoSalto);
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

        RB.velocity = new Vector2(inputMovimiento * velocidad, RB.velocity.y );

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Metodo que compara contra que se choca el protagonista
        if (other.gameObject.CompareTag("Weapon"))
        {
            countWeapon += 1;
            Destroy(other.gameObject);
            
            if (countWeapon >= 1) 
            {
                animator.SetLayerWeight(0, 0);
                animator.SetLayerWeight(1, 1);
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (countWeapon > 0)
            {
                Destroy(other.gameObject);
                countWeapon -= 1;
                cantEnemigos-=1;
                Debug.Log(cantEnemigos);
                if (cantEnemigos <= 0)
                {
                    victoria = true;
                    Win.show();
                }

                if (countWeapon == 0) 
                {
                    animator.SetLayerWeight(1, 0);
                    animator.SetLayerWeight(0, 1);
                }
            }
            else
            {
                animator.SetBool("isDeath", true);
                muerto = true;
                Over.show();
            }
            
        }
        
    }
    public void aplicarGolpe()
    {
        //Metodo para que cuando nos golpe un enemigo salgamos volando
        Vector2 direccionGolpe;


        if(countWeapon == 0)
        {
            if (RB.velocity.x > 0)
            {
                direccionGolpe = new Vector2(-1, -1);
            }
            else
            {
                direccionGolpe = new Vector2(-1, -1);
            }

            RB.AddForce(direccionGolpe * fuerzaGolpe);

        }
            
        }
}
