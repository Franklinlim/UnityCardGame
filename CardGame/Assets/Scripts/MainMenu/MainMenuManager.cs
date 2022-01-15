using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPage;
    public AudioClip buttonClick;
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = true;
        if (!PlayerPrefs.HasKey("Health")) {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
    
    private void NewGame()
    {
        PlayerPrefs.DeleteAll();
        GetComponent<AudioSource>().PlayOneShot(buttonClick);
        SceneManager.LoadScene(1);
    }
    private void Continue()
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
