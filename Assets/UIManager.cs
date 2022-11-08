using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseUI;
    [SerializeField] bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                PauseUI.SetActive(true);
                Time.timeScale = 0.0f;
                isPaused = true;
            }
            else
            {
                PauseUI.SetActive(false);
                Time.timeScale = 1.0f;
                isPaused = false;
            }
            
        }
    }
    public void OpenMainMenu()
    {
        PauseUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);

    }
}
