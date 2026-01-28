using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionManager : MonoBehaviour
{
    public static GameSessionManager Instance { get; private set; }
    
    // Variable que indica si el juego viene del menú principal
    public bool StartedFromMainMenu { get; set; }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Esto hace que persista entre escenas
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
