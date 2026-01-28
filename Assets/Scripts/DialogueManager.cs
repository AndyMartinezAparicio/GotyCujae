using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("UI Elements")]
    public GameObject dialoguePanel; // El panel completo del diálogo
    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueText;

    [Header("Settings")]
    public float typingSpeed = 0.05f;
    public bool isDialogueActive = false;
    
    private Dialogue currentDialogue;
    private int currentLineIndex = 0;
    private bool isTyping = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!isDialogueActive) return;

        // Avanzar con cualquier tecla o click
        if (Input.anyKeyDown)
        {
            if (isTyping)
            {
                // Completar línea actual
                StopAllCoroutines();
                dialogueText.text = currentDialogue.lines[currentLineIndex].line;
                isTyping = false;
            }
            else
            {
                ShowNextLine();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        if (dialogue == null || dialogue.lines.Length == 0)
        {
            Debug.LogWarning("No hay diálogo para mostrar");
            return;
        }

        currentDialogue = dialogue;
        currentLineIndex = 0;
        isDialogueActive = true;

        if(dialoguePanel != null)
            dialoguePanel.SetActive(true);

        ShowLine(currentLineIndex);
    }

    void ShowLine(int index)
    {
        if (currentDialogue.lines.Length <= index) return;

        DialogueLine line = currentDialogue.lines[index];
        
        if (characterIcon != null)
            characterIcon.sprite = line.character.icon;
        
        if (characterName != null)
            characterName.text = line.character.characterName;

        StartCoroutine(TypeText(line.line));
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    void ShowNextLine()
    {
        currentLineIndex++;
        
        if (currentLineIndex >= currentDialogue.lines.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine(currentLineIndex);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        Debug.Log("Diálogo terminado");
        // Puedes añadir aquí un evento para notificar que terminó
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
