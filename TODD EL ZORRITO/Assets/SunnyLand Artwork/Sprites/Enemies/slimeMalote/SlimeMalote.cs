using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMalote : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float distancia;
    [SerializeField] private bool moviendoDerecha = true;
    [SerializeField] private LayerMask LayerM;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Control de movimiento
        if (moviendoDerecha == true) {
            // Lo ponemos mirando a la derecha y hacemos que se mueva cada Frame
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position += Vector3.right * velocidad * Time.deltaTime;
        }

        if (moviendoDerecha == false)
        {
            // Lo ponemos mirando a la izquierda y hacemos que se mueva cada Frame
            transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.position += Vector3.left * velocidad * Time.deltaTime;
        }

        if (Physics2D.Raycast(transform.position, transform.right, distancia, LayerM)) 
        {
            moviendoDerecha =! moviendoDerecha;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * distancia);
    }
}
