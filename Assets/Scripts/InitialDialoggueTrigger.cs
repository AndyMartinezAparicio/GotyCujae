using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool hasTriggered = false;

    void Start()
    {
        // Ocultar el trigger visualmente si tiene sprite renderer
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;
        
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
    }

    void Update()
    {
        // Opcional: Activar diálogo después de un tiempo si no se ha activado
        if (!hasTriggered && ScoreManager.GetHighScore() == 0)
        {
            StartCoroutine(DelayedDialogue());
        }
    }

    IEnumerator DelayedDialogue()
    {
        hasTriggered = true;
        yield return new WaitForSeconds(0.5f);
        
        if (DialogueManager.instance != null)
        {
            DialogueManager.instance.StartDialogue(dialogue);
        }
    }
}