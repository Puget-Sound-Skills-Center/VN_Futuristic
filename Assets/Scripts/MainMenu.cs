using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int picNum = 1;
    [SerializeField] bool isAnimating = false;
    [SerializeField] GameObject fadeOut;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] int sceneToLoad;
    [SerializeField] int saveTransferValue;
    [SerializeField] GameObject fadeIn;
    void Start()
    {
        StartCoroutine(StopFade());
    }

    public void StartGame()
    {
        buttonClick.Play();
        fadeOut.SetActive(true);
        StartCoroutine(TransferToClassScene());
    }

    public void LoadGame()
    {
        saveTransferValue = PlayerPrefs.GetInt("LoadState");
        if (saveTransferValue > 0)
        {
            sceneToLoad = saveTransferValue + 1;
            buttonClick.Play();
            fadeOut.SetActive(true);
            StartCoroutine(LoadScene());
        }

    }

    public void GoToCredits()
    {
        buttonClick.Play();
        fadeOut.SetActive(true);
        StartCoroutine(TransferToCredits());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator TransferToClassScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator TransferToCredits()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(7);
    }

    IEnumerator StopFade()
    {
        yield return new WaitForSeconds(2);
        fadeIn.SetActive(false);
    }
}