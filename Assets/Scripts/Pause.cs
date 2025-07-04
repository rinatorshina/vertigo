using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] AudioSource buttonSound;

    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        
    }

    public void pauseButton()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        buttonSound.Play();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        buttonSound.Play();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

        buttonSound.Play();
    }

}
