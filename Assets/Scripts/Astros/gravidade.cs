using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gravidade : MonoBehaviour
{
    public GameObject Nave1;
    public GameObject Nave2;
    private float escalaAstro;
    // Start is called before the first frame update
    void Start()
    {
        escalaAstro = transform.localScale.x * 5;
    }

    // Update is called once per frame
    void Update()
    {
        float distN1 = Vector3.Distance(transform.position,Nave1.transform.position);
        Vector3 distanciaN1 = transform.position - Nave1.transform.position;
        float velN1 = transform.localScale.x / (100*distN1);
        if (distN1 < escalaAstro)
        {
            Nave1.transform.Translate(distanciaN1*velN1*Time.deltaTime);
        }

        float distN2 = Vector3.Distance(transform.position, Nave2.transform.position);
        Vector3 distanciaN2 = transform.position - Nave2.transform.position;
        float velN2 = transform.localScale.x / (100 * distN2);
        if (distN2 < escalaAstro)
        {
            Nave2.transform.Translate(distanciaN2 * velN2 * Time.deltaTime);
        }
    }
}
