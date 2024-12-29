using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Script_nave1 : MonoBehaviour
{
    public bool travarMouse = true;
    public float sensibilidade = 1.2f;
    private float aceleracao = 150f;
    private float turbo = 1.0f;
    private Rigidbody rb;
    public float mouseX = 0.0f, mouseY = 0.0f;
    [SerializeField] private Camera camera;
    public float field;
    private bool buttonmouse = false;
    public Vector3 direcao;
    private float velocidade;
    [SerializeField] private GameObject fogueteR;
    [SerializeField] private GameObject fogueteL;
    public float valorTeste;
    public AudioController audiofoquetes;
    public AudioClip sons;
    private bool toque = false;


    private void Awake()
    {
        // Placeholder for future initialization if needed
    }

    void Start()
    {
        velocidade = 2;
        direcao = Vector3.zero;
        camera = camera.GetComponent<Camera>();
        rb = GetComponentInChildren<Rigidbody>();
       
        if (travarMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        
        fogueteR.SetActive(false);
        fogueteL.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
        Quaternion rotacao = Quaternion.identity;
    }
    void Update()
    {
        InputPersonagem();
        //transform.Translate(direcao * velocidade * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            buttonmouse = true;
        }
        if (Input.GetMouseButton(1))
        {
            buttonmouse = false;
        }

        if (!buttonmouse)
        {
            mouseY += Input.GetAxis("Mouse X") * sensibilidade;
            mouseX += Input.GetAxis("Mouse Y") * sensibilidade;
        }

        transform.eulerAngles = new Vector3(-mouseX, mouseY, 0);

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

    public float MouseY() { return mouseY; }
    
    public float MouseX() { return mouseX; }

    void InputPersonagem()
    {
        direcao = Vector3.zero;

        if (Input.GetKey(KeyCode.Q))
        {
            turbo = 4.0f;
        }
        else
        {
            turbo = 1.0f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direcao += Vector3.forward * aceleracao * turbo;

            if (field <= 50f)
            {
                afasta();
                fogueteR.SetActive(true);
                fogueteL.SetActive(true);
            }
            
            if (aceleracao < 50)
            {
                aceleracao += 0.5f;
            }
            if (!toque)
            {
                audiofoquetes.AudioFoguestesPlay(sons);
                toque = true;
            }   
        }
        else
        {
            fogueteR.SetActive(false);
            fogueteL.SetActive(false);
            if (aceleracao > 5)
            {
                aceleracao -= 0.2f;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
           
            transform.Rotate(new Vector3(0f, -1f, 0f), (float)(Time.deltaTime * 20));
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            transform.Rotate(new Vector3(0f, 1f, 0f), (float)(Time.deltaTime * 20));

        }

        if (Input.GetKey(KeyCode.F))
        {   
            direcao += Vector3.down * 10;
        }


        if (Input.GetKey(KeyCode.R))
        {

            direcao += Vector3.up * 10;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {

            direcao += Vector3.back * aceleracao * turbo;

        }

        if ((field >= 34 & field < 51) & !Input.GetKey(KeyCode.W))
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
        audiofoquetes.AudioFoguestesStop();
        toque = false;
    }

    void afasta()
    {
        if (camera.fieldOfView < 50f)
        {
            field = camera.fieldOfView;
            camera.fieldOfView = field + 0.1f;
        }
    }
}
