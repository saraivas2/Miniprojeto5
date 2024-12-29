using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeitosSkyBox : MonoBehaviour
{
    private float timeLife = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLife-=Time.deltaTime;

        if (timeLife <= 0)
        {
            Destroy(this.gameObject);
            timeLife = 10.0f;
        } 
    }
}
