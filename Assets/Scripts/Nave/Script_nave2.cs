using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Script_nave2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float sensibilidade = 1.2f;
    private float aceleracao = 150f;
    private float turbo = 1.0f;
    [SerializeField] private Camera camera;
    public float field;
    private Rigidbody rb;
    public Vector3 vectorMov;
    Quaternion quat;
    [SerializeField] private GameObject fogueteR;
    [SerializeField] private GameObject fogueteL;


    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        fogueteR.SetActive(false);
        fogueteL.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float angleY = quat.eulerAngles.y;
        vectorMov = GetDirectionVector(angleY);

        InputPersonagem();

        field = camera.fieldOfView;
        if (field > 50f)
        {
            camera.fieldOfView = 50f;
        }
        if (field < 35f)
        {
            camera.fieldOfView = 35f;
        }
        
    }

    void InputPersonagem()
    {
        

        if (Input.GetKey(KeyCode.P))
        {
            turbo = 4.0f;
        }
        else
        {
            turbo = 1.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(vectorMov * turbo * aceleracao, ForceMode.Acceleration);

            if (field <= 50f)
            {
                fogueteL.SetActive(true);
                fogueteR.SetActive(true);
                afasta();
            }
        }
        else

        {
            fogueteL.SetActive(false);
            fogueteR.SetActive(false);

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.AddForce(-vectorMov * turbo * aceleracao, ForceMode.Acceleration);
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            quat = rb.rotation*Quaternion.Euler(0, -1, 0);
            rb.MoveRotation(quat);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            quat = rb.rotation*Quaternion.Euler(0, 1, 0);
            rb.MoveRotation(quat);
        }
       
        if (Input.GetKey(KeyCode.RightShift))
        {
            rb.AddForce(-transform.up * aceleracao, ForceMode.Acceleration);
        }


        if (Input.GetKey(KeyCode.Return))
        {
            rb.AddForce(transform.up * aceleracao, ForceMode.Acceleration);
        }
        
        if ((field >= 34 & field < 51) & !Input.GetKey(KeyCode.UpArrow))    
        {
            aproxima();
        }
        
    }

    void aproxima()
    {
        if (camera.fieldOfView > 35f)
        {
            camera.fieldOfView = field - 0.1f;
        }
    }

    void afasta()
    {
        if (camera.fieldOfView < 50f)
        {
            field = camera.fieldOfView;
            camera.fieldOfView = field + 0.1f;
        }
    }

    Vector3 GetDirectionVector(float angleY)
    {
        float radianY = angleY * Mathf.Deg2Rad;

        float x = Mathf.Sin(radianY);
        float z = Mathf.Cos(radianY);

        return new Vector3(x, 0, z);
    }
}
