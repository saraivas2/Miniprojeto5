using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class CanvasPilotos : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro1;
    public TextMeshProUGUI textMeshPro2;
    public Cameras3_4 scriptCareras34;
    private Cameras1_2 scriptCareras12;
    // Start is called before the first frame update
    private void Start()
    {
        scriptCareras12 = GetComponentInParent<Cameras1_2>();
    }

    // Update is called once per frame
    void Update()
    {
        Piloto1Text();
        Piloto2Text();
    }

    void Piloto1Text()
    {
        textMeshPro1.text = Pilotos.Instance.Piloto1();
    }

    void Piloto2Text()
    {
        string piloto2 = Pilotos.Instance.Piloto2();
        if (piloto2.Length> 0) 
        {
            textMeshPro2.text = piloto2;
        }
        else
        {
            textMeshPro2.text = "";
            scriptCareras12.ligarCamera1();
            scriptCareras34.DesligarCameras();
            scriptCareras12.viewPortCam1();

        } 
    }
}
