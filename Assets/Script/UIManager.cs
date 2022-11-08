using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] GameObject PauseUI;
    [SerializeField] bool isPaused;
    [SerializeField] GameObject PanelWin;
    [SerializeField] Image ImageWin;
    [SerializeField] Sprite Yellow;
    [SerializeField] Sprite red;
    [SerializeField] TextMeshProUGUI textWin;
    // Start is called before the first frame update
    void Start()
    {
        PauseUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }
    private void Awake()
    {
        Instance = this;
    }

    public void OpenMenu()
    {
        GameManager.instance.OpenMenu();
    }
    public void Win(bool redWin)
    {
        if (redWin)
        {
            textWin.text = "TEAM ROUGE GAGNE !!!";
            ImageWin.sprite = red;
        }
        else
        {
            textWin.text = "TEAM JAUNE GAGNE !!!";
            ImageWin.sprite = Yellow;
        }

        PanelWin.SetActive(true);
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
