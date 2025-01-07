using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.VisualScripting;

public class coletaObjetos : MonoBehaviour
{
    private GameObject objetos;
    public int countObj = 0;
    public bool coleta = false;
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
            coleta = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("pessoal"))
        {
            pessoalScritp.acena();
            if (Input.GetKey(KeyCode.M))
            {
                Destroy(other.gameObject);
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pessoal"))
        {
            pessoalScritp.acena();
            if (Input.GetKey(KeyCode.M))
            {
                Destroy(other.gameObject);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pessoal"))
        {
            pessoalScritp.parado();
        }
    }
    // Update is called once per frame
    void Update()
    {
       if (coleta)
        {
            countObj++;
            coleta=false;
        }
        texto.text = "Objetos coletados: " + countObj.ToString();
       
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
