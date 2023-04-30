using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject ReinciarText;
    public GameObject VolverText
        ;
    public static GameObject GameOverStatic;
    public static GameObject Reiniciar;
    public static GameObject Volver;


    // Start is called before the first frame update
    void Start()
    {
        Over.GameOverStatic = GameOverText;
        Over.Reiniciar = ReinciarText;
        Over.Volver= VolverText;

        //Dejarlo en invisible al empezar 
        Over.GameOverStatic.gameObject.SetActive(false);
        Over.Reiniciar.gameObject.SetActive(false);
        Over.Volver.gameObject.SetActive(false);
    }


    public static void show()
    {
        //Metodo que muestra los mensajes 
        Over.GameOverStatic.SetActive(true);
        Over.Reiniciar.SetActive(true);
        Over.Volver.SetActive(true);

    }

    public void Reinicar()
    {
        Debug.Log("Reiniciar");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void VolverMenu()
    {
        Debug.Log("Salir....");
        SceneManager.LoadScene(0);
    }
}
