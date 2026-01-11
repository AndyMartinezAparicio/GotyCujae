using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BotonStart()
    {
        SceneManager.LoadScene(1);
    }

    public void BotonSalir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
