using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPage;
    public AudioClip buttonClick;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = true;
    }
    
    private void StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene(1);
    }
    private void Instructions()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClick);
        instructionsPage.SetActive(!instructionsPage.activeSelf);
    }
    private void ExitGame()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonClick);
        Application.Quit();
    }
}
