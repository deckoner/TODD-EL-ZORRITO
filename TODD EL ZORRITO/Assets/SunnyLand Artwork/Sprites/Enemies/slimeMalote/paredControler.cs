using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredControler : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float distancia;
    [SerializeField] private Transform controlPared;
    [SerializeField] private bool moviendoDerecha;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D informacionPared = Physics2D.Raycast(controlPared.position, Vector2.right, distancia);

        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (informacionPared == false) {
            Girar();
        }
    }

    private void Girar()
    {
        moviendoDerecha = !moviendoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 100, 0);
        velocidad *= -1;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(controlPared.transform.position, controlPared.transform.position + Vector3.right * distancia);
    }
}