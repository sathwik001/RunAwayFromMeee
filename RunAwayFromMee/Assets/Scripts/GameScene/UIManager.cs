using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private Animator _pausePanelAnimator;

    private void Start()
    {
        _pausePanel.SetActive(false);        
    }
    public void OnHomePressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnRetryPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void OnPausePressed()
    {
        _pausePanel.SetActive(true);
        FindObjectOfType<PlayerJumpBehaviour>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(PauseDelay());
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1f;
        _pausePanelAnimator.SetBool("isDisappearing", true);
        StartCoroutine(ResumeDelay());
    }

    IEnumerator PauseDelay()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0f;
    }

    IEnumerator ResumeDelay()
    {
        yield return new WaitForSeconds(1.01f);
        FindObjectOfType<PlayerJumpBehaviour>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        _pausePanel.SetActive(false);
    }
}
