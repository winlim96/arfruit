using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void HowtoPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void OnClickQuit()
    {
        Application.Quit();
    }
}
