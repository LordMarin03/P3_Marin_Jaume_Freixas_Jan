using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detector : MonoBehaviour
{
    private PlayerController_senseimputsystem pC;
    public GameObject PersonajeCerca;
    public cajaTexto Texto;

    public Dictionary<string, Animator> animadores = new Dictionary<string, Animator>();
    public Animator NPC;
    public Animator player;
    public Conversation Conversation;

    private void Awake()
    {
        pC = GetComponentInParent<PlayerController_senseimputsystem>();

        animadores.Add("NPC", NPC);
        animadores.Add("player", player);
    }

    private void Update()
    {
        if (PersonajeCerca != null) // Verifica si hay un personaje cerca
        {
            persona CodigoPersona = PersonajeCerca.GetComponent<persona>();
            if (pC.PuedeHablar)
            {
                pC.PuedeHablar = false;
                pC.PuedeAndar = false;
            }
            else
            {
                StopAllCoroutines();
                Texto.CloseText();
                pC.PuedeHablar = true;
                pC.PuedeAndar = true;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
            PersonajeCerca = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
            PersonajeCerca = null;
    }
}
