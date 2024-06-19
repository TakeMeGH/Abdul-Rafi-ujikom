using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button Play;
    [SerializeField] Button Exit;

    // Start is called before the first frame update
    void Start()
    {
        Play.onClick.AddListener(OnPlay);
        Exit.onClick.AddListener(OnExit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    void OnExit()
    {
        Application.Quit();
    }
}
