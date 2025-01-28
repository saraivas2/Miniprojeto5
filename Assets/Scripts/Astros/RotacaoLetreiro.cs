using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoLetreiro : MonoBehaviour
{
    public GameObject nave1;
    public GameObject nave2;

    // Update is called once per frame
    void Update()
    {
        float distance1 = Vector3.Distance(transform.position, nave1.transform.position);
        float distance2 = Vector3.Distance(transform.position, nave2.transform.position);
        if (distance1 < 200 | distance2<200)
        {
            if (distance1 < distance2)
            {
                transform.rotation = nave1.transform.rotation;
            }
            else
            {
                transform.rotation = nave2.transform.rotation;
            }
        }
    }
}
