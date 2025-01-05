using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Script_text_plutao : MonoBehaviour
{
    public GameObject Sol;
    public GameObject Mercurio;
    public GameObject Venus;
    public GameObject Terra;
    public GameObject Marte;
    public GameObject Jupiter;
    public GameObject Saturno;
    public GameObject Urano;
    public GameObject Netuno;
    public GameObject Plutao;
    public GameObject Nave;
    public GameObject SolText;
    public GameObject MercurioTex;
    public GameObject VenusTex;
    public GameObject TerraTex;
    public GameObject MarteTex;
    public GameObject JupiterTex;
    public GameObject SaturnoTex;
    public GameObject UranoTex;
    public GameObject NetunoTex;
    public GameObject PlutaoTex;
    private Vector3 posiNave;
    public TextMesh Text_Nave;
    static DropDownScript telaInicial;
    string piloto1,piloto2;
    public bool nave1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Calcula a distância entre Terra e Nave
            float sol = Vector3.Distance(Sol.transform.position, Nave.transform.position);
            float mercurio = Vector3.Distance(Mercurio.transform.position, Nave.transform.position);
            float venus = Vector3.Distance(Venus.transform.position, Nave.transform.position);
            float terra = Vector3.Distance(Terra.transform.position, Nave.transform.position);
            float marte = Vector3.Distance(Marte.transform.position, Nave.transform.position);
            float jupiter = Vector3.Distance(Jupiter.transform.position, Nave.transform.position);
            float saturno = Vector3.Distance(Saturno.transform.position, Nave.transform.position);
            float urano = Vector3.Distance(Urano.transform.position, Nave.transform.position);
            float netuno = Vector3.Distance(Netuno.transform.position, Nave.transform.position);
            float plutao = Vector3.Distance(Plutao.transform.position, Nave.transform.position);
            
            if (sol <= mercurio)
            {
                Text_Nave.text =  " Sol: " + sol.ToString("F2");
                Text_Nave.color = Color.white; 
                SolText.transform.rotation = Nave.transform.rotation;
            }
            else if (mercurio <= venus)
            {
                Text_Nave.text =  " Mercurio: " + mercurio.ToString("F2");
                Text_Nave.color = Color.white; 
                MercurioTex.transform.rotation = Nave.transform.rotation;
            }
            else if (venus <= terra)
            {
                Text_Nave.text =  " Venus: " + venus.ToString("F2");
                Text_Nave.color = Color.white; 
                VenusTex.transform.rotation = Nave.transform.rotation;
            }
            else if (terra <= marte)
            { 
                Text_Nave.text =  " Terra: " + terra.ToString("F2");
                Text_Nave.color = Color.white; 
                TerraTex.transform.rotation = Nave.transform.rotation;
            }
            else if (marte <= jupiter)
            {
                Text_Nave.text =  " Marte: " + marte.ToString("F2");
                Text_Nave.color = Color.white; 
                MarteTex.transform.rotation = Nave.transform.rotation;
            }
            else if (jupiter <= saturno)
            {
                Text_Nave.text =  " Jupiter: " + jupiter.ToString("F2");
                Text_Nave.color = Color.white; 
                JupiterTex.transform.rotation = Nave.transform.rotation;
            }
            else if (saturno <= urano)
            {
                Text_Nave.text =  " Saturno : " + saturno.ToString("F2");
                Text_Nave.color = Color.white; 
                SaturnoTex.transform.rotation = Nave.transform.rotation;
            }
            else if (urano <= netuno)
            {
                Text_Nave.text =  " Urano: " + urano.ToString("F2");
                Text_Nave.color = Color.white; 
                UranoTex.transform.rotation = Nave.transform.rotation;
            }
            else if (netuno <= plutao)
            {
                Text_Nave.text =  " Netuno: " + netuno.ToString("F2");
                Text_Nave.color = Color.white; 
                NetunoTex.transform.rotation = Nave.transform.rotation;
            }
            else if (plutao < netuno)
            {
                Text_Nave.text =  " Plutão: " + plutao.ToString("F2");
                Text_Nave.color = Color.white; 
                PlutaoTex.transform.rotation = Nave.transform.rotation;
            }
    }
}
