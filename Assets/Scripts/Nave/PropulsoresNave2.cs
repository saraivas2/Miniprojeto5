using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PropulsoresNave2 : MonoBehaviour
{
    public float sensibilidade = 3f;
    private float maxAngle = 25f; 
    private float transfx, transfy;
    public GameObject nave;
    private float timeCount=0.1f;
    public GameObject propulsor;


    private void Start()
    {
        
    }

    void Update()
    {
        transfx = nave.transform.rotation.x;
        transfy = nave.transform.rotation.y;
        
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

        if (Input.GetKey(KeyCode.P)) 
        {
            propulsor.transform.localScale = new Vector3(0.02f, 0.02f, 0.03f);
        }
        else
        {
            propulsor.transform.localScale = new Vector3(0.01f, 0.01f, 0.02f);
        }

    }

}
