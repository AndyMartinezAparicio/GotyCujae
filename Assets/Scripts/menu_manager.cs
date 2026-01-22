using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu_manager : MonoBehaviour
{
    [SerializeField] private GameObject panelCreditos;
    [SerializeField] private GameObject panelAjustes;

    [SerializeField] private Toggle toggleMusica;
    [SerializeField] private Image toggleMusicaBackground;

    [SerializeField] private Sprite spriteAudioOn;
    [SerializeField] private Sprite spriteAudioOff;

    public AudioSource musicaFondo;
    public AudioSource efectosAudio;

    public Sprite spriteHover;
    public Sprite spriteNormal;

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

    public void BotonBack()
    {
        SceneManager.LoadScene(0);
    }

    public void BotonSalir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }


    public void ShowCredits()
    {

        panelCreditos.SetActive(true);
    }

    public void HideCredits()
    {

        panelCreditos.SetActive(false);
    }

    public void ShowAjustes()
    {
        panelAjustes.SetActive(true);
    }

    public void HideAjustes()
    {
        panelAjustes.SetActive(false);
    }

    public void ToggleMusica(bool activo)
    {
        // Activar o desactivar la música 
        musicaFondo.mute = !activo;

        // Cambiar el icono del toggle 
        toggleMusicaBackground.sprite = activo ? spriteAudioOn : spriteAudioOff;
    }

    // --------------------------------------------------------- 
    // MÉTODOS PARA HOVER
    // --------------------------------------------------------- 

    // Cuando el mouse entra en el botón  
    public void OnHoverEnter(Image botonImage)
    {
        if (spriteHover != null)
            botonImage.sprite = spriteHover;
    }

    // Cuando el mouse sale del botón 
    public void OnHoverExit(Image botonImage)
    {
        if (spriteNormal != null)
            botonImage.sprite = spriteNormal;
    }
}
