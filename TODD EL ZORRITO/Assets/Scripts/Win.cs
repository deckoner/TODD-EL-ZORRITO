using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject GameOverText;
    public GameObject SiguienteText;
        
    public static GameObject GameOverStatic;
    public static GameObject Siguiente;


    // Start is called before the first frame update
    void Start()
    {
        Win.GameOverStatic = GameOverText;
        Win.Siguiente = SiguienteText;

        //Dejarlo en invisible al empezar 
        Win.GameOverStatic.gameObject.SetActive(false);
        Win.Siguiente.gameObject.SetActive(false);
    }


    public static void show()
    {
        //Metodo que muestra los mensajes 
        Win.GameOverStatic.SetActive(true);
        Win.Siguiente.SetActive(true);

    }

    public void SiguienteScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
