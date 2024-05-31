using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generador : MonoBehaviour
{
    public GameObject[] personajes;
    public int valorAsesino;
    public string nombreAsesino;

    public GameObject Asesino;
    public List<GameObject> Inocentes = new List<GameObject>();
    public GameObject Testigo1;
    [Space(10)]
    public float a;

    private string[] Inocents;
    private int Assassi;
    private string Testimoni1;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond); // Inicializa el generador aleatorio con la semilla del tiempo actual
        GenerarAsesino();
    }

    void GenerarAsesino()
    {
        valorAsesino = Random.Range(0, personajes.Length); // Asigna un valor aleatorio a valorAsesino

        Asesino = personajes[valorAsesino];
        nombreAsesino = Asesino.name;
        Asesino.gameObject.tag = "asesino";
        GenerarTestigos();
    }

    void GenerarTestigos()
    {
        Inocentes.Clear(); // Limpia la lista de inocentes antes de cada nueva generación

        // Añadir todos los personajes a la lista de inocentes excepto el asesino
        foreach (var personaje in personajes)
        {
            if (personaje != Asesino)
            {
                Inocentes.Add(personaje);
            }
        }

        if (Inocentes.Count > 0)
        {
            Testigo1 = Inocentes[Random.Range(0, Inocentes.Count)];
            Inocentes.Remove(Testigo1);

            Testigo1.tag = "testigo";
            var testigoPersona = Testigo1.GetComponent<persona>();

            Asesino.tag = "asesino";
            var asesinoPersona = Asesino.GetComponent<persona>();


            foreach (GameObject inocente in Inocentes)
            {
                inocente.tag = "inocente";
                var inocentePersona = inocente.GetComponent<persona>();
            }
        }
        else
        {
            Debug.LogError("No hay suficientes personajes para generar un asesino, un testigo y al menos un inocente.");
        }
    }
}