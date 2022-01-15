using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    private void MainMenu() {
        SceneManager.LoadScene(0);
    }
}
