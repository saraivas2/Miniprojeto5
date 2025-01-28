using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class coletaObjetos : MonoBehaviour
{
    private GameObject objetos;
    public int countObj = 0;
    public int countPessoal = 0;
    int valor = 1;
    float timeReg = 3f;
    public bool coletaPessoa = false;
    public bool coletaObj = false;
    private TextMeshProUGUI texto;
    public pessoal pessoalScritp;
    
    // Start is called before the first frame update
    void Start()
    {
        texto = GameObject.FindWithTag("TextCanvas").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("objeto"))
        {
            countObj++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("pessoal"))
        {
            countPessoal++;
            Destroy(other.gameObject);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        timeReg -= Time.deltaTime;
        if (timeReg < 0)
        {
            valor *= -1;
            timeReg = 3;
        }

        if (valor>0)
        {
            texto.text = "Objetos coletados: " + countObj.ToString();
        }
        else
        {
            texto.text = "Pessoas coletadas: " + countPessoal.ToString();
        }
        
       
        if (countObj == 10)
        {
            EndGame();
         
        }
    }
    void EndGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }


}
