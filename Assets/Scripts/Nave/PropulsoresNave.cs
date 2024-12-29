using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PropulsoresNave : MonoBehaviour
{
    public float sensibilidade = 3f;
    private float maxAngle = 25f; // Ângulo máximo de inclinação
    private float transfx, transfy;
    private GameObject nave;
    private float timeCount=0.1f;

    private void Start()
    {
        nave = GameObject.FindWithTag("nave").GetComponent<GameObject>();
    }

    void Update()
    {
        transfx = GetComponentInParent<Script_nave1>().mouseX * sensibilidade;
        transfy = GetComponentInParent<Script_nave1>().mouseY * sensibilidade;
        
        movimentaPropulsores(transfx, transfy);
    }

    private void movimentaPropulsores(float transfx, float transfy)
    {
        transfx = Mathf.Clamp(transfx, -maxAngle, maxAngle);
        transfy = Mathf.Clamp(transfy, -maxAngle, maxAngle);
        float transfz = Mathf.Clamp(0, -maxAngle, maxAngle);

        Quaternion targetRotation = Quaternion.Euler(transfx, transfy, transfz);
        correcaoRotacao(targetRotation);
    }

    private void correcaoRotacao(Quaternion rotacao)
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.localRotation = Quaternion.Slerp(rotacao, Quaternion.identity, timeCount);
            timeCount = timeCount + Time.deltaTime;
        }
        else
        {
            transform.localRotation = rotacao;
        }
        

    }

}
