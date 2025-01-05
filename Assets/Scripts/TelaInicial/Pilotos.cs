using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class Pilotos : MonoBehaviour
{
    public static Pilotos Instance;
    [SerializeField] private string piloto1;
    [SerializeField] private string piloto2;
    

    private void Start()
    {
     
    }
    private void Awake()
    {
        if(Pilotos.Instance == null)
        {
            Pilotos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPiloto1(string pi1)
    {
        piloto1 = pi1;
    }

    public void SetPiloto2(string pil2)
    {
        piloto2 = pil2;
    }
    public string Piloto1()
    {
        return piloto1;
    }

    public string Piloto2() 
    {
        return piloto2;
    }
}
