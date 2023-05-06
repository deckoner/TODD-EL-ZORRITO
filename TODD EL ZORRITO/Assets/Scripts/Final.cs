using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{   
    //metodo que te devuelve al menu
    public void VolverMenu()
    {
        Debug.Log("Salir....");
        SceneManager.LoadScene(0);
    }
}

