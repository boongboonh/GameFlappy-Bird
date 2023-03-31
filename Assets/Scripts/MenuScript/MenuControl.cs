using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuControl : MonoBehaviour
{


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
       
    }

   
    void Update()
    {
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void QuitGame()
    {
        Debug.Log("out game");
        Application.Quit();
    }



}
