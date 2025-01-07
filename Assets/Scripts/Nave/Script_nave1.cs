    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;

    public class Script_nave1 : MonoBehaviour
    {
        public bool travarMouse = true;
        public float sensibilidade = 1.2f;
        public float aceleracao = 250f;
        private float turbo = 1.0f;
        private Rigidbody rb;
        public float mouseX = 0.0f, mouseY = 0.0f;
        [SerializeField] private Camera camera;
        public float field;
        private bool buttonmouse = false;
        [SerializeField] private GameObject fogueteR;
        [SerializeField] private GameObject fogueteL;
        public AudioController audiofoquetes;
        public AudioClip sons;
        private bool toque = false;
        public Quaternion quat;
        public float angleY;
        public Vector3 CamVect;

        void Start()
        {
            rb = GetComponentInChildren<Rigidbody>();
       
            if (travarMouse)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        
            fogueteR.SetActive(false);
            fogueteL.SetActive(false);
        }

   
        void Update()
        {

            if (!buttonmouse)
            {
                mouseY += Input.GetAxis("Mouse X") * sensibilidade;
                mouseX += Input.GetAxis("Mouse Y") * sensibilidade;
            }
            
            quat = Quaternion.Euler(-mouseX, mouseY, 0);
            
            InputPersonagem();
        
            if (Input.GetMouseButton(0))
            {
                buttonmouse = true;
            }
            if (Input.GetMouseButton(1))
            {
                buttonmouse = false;
            }

            rb.MoveRotation(quat);

            field = camera.fieldOfView;
            if (field > 50f)
            {
                camera.fieldOfView = 50f;
            }
            if (field < 35f)
            {
                camera.fieldOfView = 35f;
            }
            
            angleY = quat.eulerAngles.y; 
            CamVect = GetDirectionVector(angleY);
        }

        public float MouseY() { return mouseY; }
    
        public float MouseX() { return mouseX; }

        void InputPersonagem()
        {
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
                rb.AddForce(CamVect * turbo * aceleracao, ForceMode.Acceleration);

                if (field <= 50f)
                {
                    afasta();
                    fogueteR.SetActive(true);
                    fogueteL.SetActive(true);
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
                if (Input.GetKey(KeyCode.S))
                {
                    rb.AddForce(turbo * -CamVect * aceleracao, ForceMode.Acceleration);
                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(turbo * -CamVect * aceleracao, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.A))
            {
                //rb.AddForce(-new Vector3(CamVect.z, 0, CamVect.x) * aceleracao,ForceMode.Acceleration);
                quat = rb.rotation * Quaternion.Euler(0, -1, 0);
                mouseY = quat.eulerAngles.y;
            }

            if (Input.GetKey(KeyCode.D))
            {
                //rb.AddForce(new Vector3(CamVect.z,0, CamVect.x) * aceleracao, ForceMode.Acceleration);
                quat = rb.rotation * Quaternion.Euler(0, 1, 0);
                mouseY = quat.eulerAngles.y;
            }

            if (Input.GetKey(KeyCode.R))
            {
                rb.AddForce(transform.up * aceleracao, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.F))
            {
                rb.AddForce(-transform.up * aceleracao, ForceMode.Acceleration);
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

        Vector3 GetDirectionVector(float angleY)
        {
            float radianY = angleY * Mathf.Deg2Rad;

            float x = Mathf.Sin(radianY);
            float z = Mathf.Cos(radianY);
    
            return new Vector3(x, 0, z);
        }
    }
