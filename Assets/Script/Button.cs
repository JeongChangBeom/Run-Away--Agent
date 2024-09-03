using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void StartGame()
    {
        Time.timeScale = 1;
        SoundManager.instance.ButtonBullet_Play();
        Invoke("StartGameload", 2.2f);
        GameObject.Find("Canvas").transform.Find("Bullet").gameObject.SetActive(true);
    }

    public void StartGameload()
    {
        SceneManager.LoadScene("Explanation");
    }
    
    public void Next()
    {
        SoundManager.instance.ButtonNext_Play();
        SceneManager.LoadScene("Explanation2");
    }

    public void GameStart()
    {
        SoundManager.instance.ButtonBullet_Play();
        Invoke("GameStartload", 2.2f);
        GameObject.Find("Canvas").transform.Find("Panel").transform.Find("bullet").gameObject.SetActive(true);
    }

    public void GameStartload()
    {
        SceneManager.LoadScene("Stage01");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Option()
    {
        SoundManager.instance.ButtonNext_Play();
        GameObject.Find("Canvas").transform.Find("Option").gameObject.SetActive(true);
    }

    public void OptionBack()
    {
        GameObject.Find("Canvas").transform.Find("Option").gameObject.SetActive(false);
    }

    public void Stage01_01()
    {
        SoundManager.instance.ButtonBullet_Play();
        GameObject.Find("Canvas").transform.Find("Clear").transform.Find("Stage01_01").transform.Find("bullet").gameObject.SetActive(true);
        StartCoroutine(Stage01_01load());
    }

    IEnumerator Stage01_01load()
    {
        yield return new WaitForSecondsRealtime(2.2f);
        SceneManager.LoadScene("Stage01_01");

    }
    public void Stage01_02()
    {
        SoundManager.instance.ButtonBullet_Play();
        GameObject.Find("Canvas").transform.Find("Clear").transform.Find("Stage01_02").transform.Find("bullet").gameObject.SetActive(true);
        StartCoroutine(Stage01_02load());
    }
    IEnumerator Stage01_02load()
    {
        yield return new WaitForSecondsRealtime(2.2f);
        SceneManager.LoadScene("Stage01_02");

    }

    public void Stage01_01_01()
    {
        SoundManager.instance.ButtonBullet_Play();
        GameObject.Find("Canvas").transform.Find("Clear").transform.Find("Stage01_01_01").transform.Find("bullet").gameObject.SetActive(true);
        StartCoroutine(Stage01_01_01load());
    }
    IEnumerator Stage01_01_01load()
    {
        yield return new WaitForSecondsRealtime(2.2f);
        SceneManager.LoadScene("Stage01_01_01");

    }

    public void Stage02()
    {
        SoundManager.instance.ButtonBullet_Play();
        GameObject.Find("Canvas").transform.Find("Clear").transform.Find("Stage02").transform.Find("bullet").gameObject.SetActive(true);
        StartCoroutine(Stage02load());
    }
    IEnumerator Stage02load()
    {
        yield return new WaitForSecondsRealtime(2.2f);
        SceneManager.LoadScene("Stage02");

    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}