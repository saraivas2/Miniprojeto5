using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pousoNave : MonoBehaviour
{

    public GameObject pouso;
    public Vector3 pousoposition;
    public float pousoy;
    public bool tal = false;
    // Start is called before the first frame update
    void Start()
    {

        //de 0.00098 para -0.00062 = 0,00036       
    }

    // Update is called once per frame
    void Update()
    {

        pousoposition = pouso.transform.localPosition;

        pousoy = pousoposition.y;

        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            if (pousoy > 0.0009)
            {
                tal = true;
                calc(pousoy,tal);   
            }
            else
            {
                tal = false;
                calc(pousoy, tal);
            }
        }
    }

    private void calc(float val, bool tal)
    {
        if (tal)
        {
            while (val > pousoy - 0.00039f)
            {
                val -= 0.000000001f;
                transform.localPosition = new Vector3(pousoposition.x, val, pousoposition.z);
            }
        }
        else
        {
            while (val < pousoy + 0.00039f)
            {
                val += 0.000000001f; ;
                transform.localPosition = new Vector3(pousoposition.x, val, pousoposition.z);
            }
        }
    }
}
