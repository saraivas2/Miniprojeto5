using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DropDownScript : MonoBehaviour
{
    public string piloto1, piloto2;
    public TMP_InputField inputFieldPiloto1;
    public TMP_InputField inputFieldPiloto2;
    public Text TextMesh1;
    public Text TextMesh2;
    public Button Button1;
    public int dropdownInt;

    private void Start()
    {
        inputFieldPiloto1.gameObject.SetActive(false);
        inputFieldPiloto2.gameObject.SetActive(false);
        TextMesh1.gameObject.SetActive(false);
        TextMesh2.gameObject.SetActive(false); 
        Button1.gameObject.SetActive(false);  
    }

    private void Update()
    {
        InputTextPilotos();
    }

    public void _DropDown(int valor)
    {
        switch (valor) 
        { 
            case 0:
                TextMesh1.gameObject.SetActive(false);
                TextMesh2.gameObject.SetActive(false);
                inputFieldPiloto1.gameObject.SetActive(false);
                inputFieldPiloto2.gameObject.SetActive(false);
                dropdownInt = valor;
                break;
            case 1:
                TextMesh1.gameObject.SetActive(true);
                inputFieldPiloto1.gameObject.SetActive(true);
                TextMesh2.gameObject.SetActive(false);
                inputFieldPiloto2.gameObject.SetActive(false);
                dropdownInt = valor;
                break;
            case 2:
                TextMesh1.gameObject.SetActive(true);
                inputFieldPiloto1.gameObject.SetActive(true);
                TextMesh2.gameObject.SetActive(true);
                inputFieldPiloto2.gameObject.SetActive(true);
                dropdownInt = valor;
                break;
        }
        
    }

    void InputTextPilotos()
    {
        if (inputFieldPiloto1.text != "" && dropdownInt == 1)
        {
            Button1.gameObject.SetActive(true);
            PilotoUm();
        }

        else if (inputFieldPiloto1.text != "" && inputFieldPiloto2.text != "" && dropdownInt == 2)
        {
            Button1.gameObject.SetActive(true);
            PilotoUm();
            PilotoDois();
        }
        else
        {
            Button1.gameObject.SetActive(false);
        }
    }
    void PilotoUm()
    {
        piloto1 = inputFieldPiloto1.text;
        Pilotos.Instance.SetPiloto1(piloto1);
    }

    void PilotoDois()
    {
        piloto2 = inputFieldPiloto2.text;
        Pilotos.Instance.SetPiloto2(piloto2);
    }
}
