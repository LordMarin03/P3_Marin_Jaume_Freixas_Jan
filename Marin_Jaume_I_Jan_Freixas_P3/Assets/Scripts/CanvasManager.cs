using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public Canvas Canvas; // Reference to the main canvas
    //public Canvas Canvas2; // Reference to the canvas for extra games
    public Canvas CanvasPanelTask; // Reference to the canvas for extra games
                                   // public GameObject PanelTask;
                                   //public GameObject MinijocCables;
    public GameObject MinijocFruites;

    public GameObject MusicaPrincipal;
    public GameObject MusicaMinijoc;

    public GameObject MinijocPanelTask;
    public GameObject InstruccionsPanelTask;

    public Canvas CanvasMemory;
    public GameObject CanvasPuzzle;
    public GameObject CanvasTalps;
    public Canvas CanvasCubos;

    public Canvas CanvasMinimap;

    public Camera Camera; // Reference to the main camera
    //public Camera MainCamera; // Reference to the camera for extra games

    private void Start()
    {
        // PanelTask.SetActive(false);
        //MinijocCables.SetActive(false);
        MinijocFruites.SetActive(false);

        //Canvas2.gameObject.SetActive(false);
        CanvasTalps.gameObject.SetActive(false);
        CanvasPuzzle.gameObject.SetActive(false);
        CanvasMemory.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(false);
        CanvasMinimap.gameObject.SetActive(true);
        CanvasCubos.gameObject.SetActive(false);

    }
    // Update is called once per frame
    /*void Update()
    {
        // Check if the "P" key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle between main canvas and extra game canvas
            //ToggleCanvas2();

        }
    }*/

    // Method to activate the main canvas and deactivate the extra game canvas
    public void ActivateCanvas()
    {
        Canvas.gameObject.SetActive(true);
        MusicaPrincipal.gameObject.SetActive(true);

        //Canvas2.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(false);

        Camera.enabled = true;
        //MainCamera.enabled = false;
    }

    // Method to activate the extra game canvas and deactivate the main canvas
    public void ActivateCanvas2()
    {
        Canvas.gameObject.SetActive(false);

        // Canvas2.gameObject.SetActive(true);
        CanvasPanelTask.gameObject.SetActive(true);

        InstruccionsPanelTask.gameObject.SetActive(true);
        MinijocPanelTask.gameObject.SetActive(false);

        Invoke("ActivarMinijoc", 8.0f);


        // Camera.enabled = false;
        //MainCamera.enabled = true;
    }
    public void ActivarMinijoc()
    {
        InstruccionsPanelTask.gameObject.SetActive(false);
        MinijocPanelTask.gameObject.SetActive(true);

        MusicaPrincipal.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(true);
    }

    public void ToggleCanvas2()
    {
        if (CanvasPanelTask.gameObject.activeSelf)
        {
            ActivateCanvas();
        }
        else
        {
            ActivateCanvas2();  
        }
    }

    public void ActivateCanvasMemory()
    {
        CanvasTalps.gameObject.SetActive(false);
        CanvasMemory.gameObject.SetActive(true);
        CanvasPuzzle.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        CanvasCubos.gameObject.SetActive(false);
        MusicaPrincipal.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(true);

    }
    public void ActivateCanvasPuzzle()
    {
        CanvasMinimap.gameObject.SetActive(false);
        CanvasTalps.gameObject.SetActive(false);
        CanvasPuzzle.gameObject.SetActive(true);
        CanvasMemory.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        CanvasCubos.gameObject.SetActive(false);
        MusicaPrincipal.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(true);
        Camera.enabled = false;
    }
    public void ActivateCanvasTalps()
    {
        CanvasTalps.gameObject.SetActive(true);

        CanvasMinimap.gameObject.SetActive(false);
        CanvasPuzzle.gameObject.SetActive(false);
        CanvasCubos.gameObject.SetActive(false);
        CanvasMemory.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        MusicaPrincipal.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(true);
        Camera.enabled = false;
    }
    public void ActivateCanvasCubos()
    {
        CanvasCubos.gameObject.SetActive(true);

        CanvasTalps.gameObject.SetActive(false);
        CanvasMinimap.gameObject.SetActive(false);
        CanvasPuzzle.gameObject.SetActive(false);
        CanvasMemory.gameObject.SetActive(false);
        CanvasPanelTask.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(false);
        MusicaPrincipal.gameObject.SetActive(false);
        MusicaMinijoc.gameObject.SetActive(true);
        Camera.enabled = false;
    }
}