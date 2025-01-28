using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pessoal : MonoBehaviour
{
    private Animator animator;
    public GameObject pessoa;
    public GameObject nave1;
    public GameObject nave2;
    public float dist;
    public float dist1;
    
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(pessoa.transform.position, nave1.transform.position);
        dist1 = Vector3.Distance(pessoa.transform.position, nave2.transform.position);

        if (dist < 10 | dist1 < 10)
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
    }

    public void parado()
    {
        animator.SetBool("acena", false);
        animator.SetBool("espera", true);
    }
}
