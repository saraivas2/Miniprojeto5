using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGame : MonoBehaviour
{
    
    public void SceneGameLoad(string cena)
    {
        SceneManager.LoadScene(cena);
    }
}
