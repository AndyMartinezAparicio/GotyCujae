using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_manager : MonoBehaviour
{
    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject panelAjustes;
    
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


    public void ShowCredits() { 
        
        panelCreditos.SetActive(true); 
    } 
    
    public void HideCredits() { 
        
        panelCreditos.SetActive(false); 
    }

    public void ShowAjustes() { 
        panelAjustes.SetActive(true); 
    } 
    
    public void HideAjustes() { 
        panelAjustes.SetActive(false); 
    }
}
