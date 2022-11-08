using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{
    public static CanvasMenu instance;
    [SerializeField] GameObject YellowGO;
    [SerializeField] GameObject RedGo;
    [SerializeField] GameObject PrefabButton;    [SerializeField] GameObject redButton;
    [SerializeField] TextMeshProUGUI jaune;
    [SerializeField] TextMeshProUGUI rouge;
    [SerializeField] TextMeshProUGUI totalplayer;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddYellowPlayer(string name, int total, int yellowamount)
    {
        GameObject go = Instantiate(PrefabButton, YellowGO.transform);
        go.GetComponentInChildren<Text>().text = name;
        go.transform.SetAsFirstSibling();
        jaune.text = "X " + yellowamount.ToString();
        totalplayer.text = "X " + total.ToString();
    }

    public void AddRedPlayer(string name, int total, int redamount)
    {
        GameObject go = Instantiate(redButton, RedGo.transform);
        go.GetComponentInChildren<Text>().text = name;
        go.transform.SetAsFirstSibling();
        rouge.text = "X " + redamount.ToString();
        totalplayer.text = "X " + total.ToString();
    }
    public void OpenLevel()
    {
        SceneManager.LoadScene("SampleScene");
        GameManager.instance.LaunchGame();
    }
}
