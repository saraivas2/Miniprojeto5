using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pessoal : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public GameObject pessoa;
    public GameObject nave1;
    public GameObject nave2;
    public bool perto = false;
    
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
       controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(pessoa.transform.position, nave1.transform.position);
        float dist1 = Vector3.Distance(pessoa.transform.position, nave2.transform.position);

        if (dist > 50 | dist1 >50)
        {
            acena();
        }
        else
        {
            parado();
        }

    }

    public void acena()
    {
        animator.SetBool("acena", true);
        animator.SetBool("espera", false);

        perto = true;
    }

    public void parado()
    {
        animator.SetBool("acena", false);
        animator.SetBool("espera", true);
        perto = false;
    }
}
