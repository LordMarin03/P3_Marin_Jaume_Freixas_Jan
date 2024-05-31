using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private PlayerController_senseimputsystem pC;
    public GameObject PersonajeActual;
    public cajaTexto Texto;

    public Dictionary<string, Animator> animadores = new Dictionary<string, Animator>();
    public Animator NPC;
    public Animator player;
    public Conversation ConversationAssasi;
    public Conversation ConversationTestimoni;
    public Conversation ConversationInocent;

    public float rotationSpeed = 180f;  // Velocidad de rotación del NPC

    private void Awake()
    {
        animadores.Add("NPC", NPC);
        animadores.Add("player", player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pC = other.GetComponent<PlayerController_senseimputsystem>();

            if (pC != null)
            {
                PersonajeActual = gameObject;

                if (pC.PuedeHablar)
                {
                    pC.PuedeHablar = false;
                    pC.DisableMovement();

                    string personajeTag = gameObject.tag;

                    if (personajeTag == "asesino")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationAssasi, gameObject);
                    }
                    else if (personajeTag == "inocente")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationInocent, gameObject);
                    }
                    else if (personajeTag == "testigo")
                    {
                        DialogueManager.Instance.StartDialogue(ConversationTestimoni, gameObject);
                    }

                    // Rotar el NPC hacia el jugador
                    StartCoroutine(RotateNPCToPlayer(pC.transform));
                }
            }
        }
    }

    private IEnumerator RotateNPCToPlayer(Transform playerTransform)
    {
        while (true)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            direction.y = 0f;

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);

            // Rotar el NPC hacia el jugador
            if (angleDifference > 0.1f)
            {
                float step = rotationSpeed * Time.deltaTime * Mathf.Min(angleDifference / 10.0f, 1.0f); // Factor de amortiguación para ralentizar la rotación a medida que se acerca
                Quaternion smoothRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
                transform.rotation = smoothRotation;
            }
            else
            {
                transform.rotation = targetRotation; // Ajustar la rotación al objetivo para detener la vibración
                yield break; // Salir de la corrutina cuando la rotación esté completa
            }

            yield return null;
        }
    }

    public void EndDialogue()
    {
        if (pC != null)
        {
            pC.PuedeHablar = true;
            pC.EnableMovement();
        }
    }
}
