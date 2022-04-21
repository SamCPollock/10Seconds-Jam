using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] canvases; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeCanvas(int canvasId)
    {
        foreach(GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }

        canvases[canvasId].SetActive(true);
    }
}
