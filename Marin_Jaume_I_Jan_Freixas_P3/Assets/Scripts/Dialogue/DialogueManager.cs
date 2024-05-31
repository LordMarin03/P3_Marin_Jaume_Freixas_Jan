using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Animator dialogueAnimator;

    public static DialogueManager Instance;

    private DialogueNode _currentNode;

    private GameObject _talker;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI SpeechText;
    public TextMeshProUGUI[] OptionsText;

    private DialogueTrigger _currentDialogueTrigger;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    public void StartDialogue(Conversation conversation, GameObject talker)
    {
        _talker = talker;
        _currentNode = conversation.StartNode;
        NameText.text = conversation.Name;
        SetNode(_currentNode);
        ShowDialogue();

        // Obtenemos el DialogueTrigger del objeto que inicia el diálogo
        _currentDialogueTrigger = talker.GetComponent<DialogueTrigger>();
    }

    private void SetNode(DialogueNode currentNode)
    {
        SpeechText.text = currentNode.Text;
        for (int i = 0; i < OptionsText.Length; i++)
        {
            if (i < currentNode.Options.Count)
            {
                OptionsText[i].transform.parent.gameObject.SetActive(true);
                OptionsText[i].text = currentNode.Options[i].Text;
            }
            else
            {
                OptionsText[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void ShowDialogue()
    {
        dialogueAnimator.SetBool("Show", true);
    }
    public void HideDialogue()
    {
        dialogueAnimator.SetBool("Show", false);

        // Llamamos a EndDialogue cuando se oculta el diálogo
        if (_currentDialogueTrigger != null)
        {
            _currentDialogueTrigger.EndDialogue();
            _currentDialogueTrigger = null;
        }
    }
    public void OptionChosen(int i)
    {
        _currentNode = _currentNode.Options[i].NextNode;
        if (_currentNode is EndNode)
        {
            Invoke("HideDialogue", 3);
            EndNode endNode = _currentNode as EndNode;
            endNode.OnChosen(_talker);
        }
        SetNode(_currentNode);
    }
}
