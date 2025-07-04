using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] AudioSource playSound;
    [SerializeField] AudioSource buttonSound;
    [SerializeField] AudioSource menuMusic;
    [SerializeField] private float timeBeforeSwitch = 2f;

    public bool playPressed = false;
    public float elapsedTime = 0f;

    public GameObject creditsUI;

    private void Start()
    {
        Time.timeScale = 1.0f;
        playPressed = false;
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (playPressed)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= timeBeforeSwitch)
            {
                startGame();
            }
        }
    }

    public void Play()
    {
        
        playPressed = true;
        playSound.Play();

        Animator animator = menuMusic.GetComponent<Animator>();
        animator.SetBool("buttonPressed", true);

    }

    public void Credits()
    {
        creditsUI.SetActive(true);
        buttonSound.Play();
    }

    public void Back()
    {
        creditsUI.SetActive(false);
        buttonSound.Play();
    }

    private void startGame()
    {
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }
}
