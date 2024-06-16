using System.Collections;
using System.Collections.Generic;
using Eflatun.SceneReference;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup panelMain;
    [SerializeField] Button buttonNewGame;
    [SerializeField] Button buttonLevelSelection;
    [SerializeField] Button buttonExit;

    [SerializeField] private CanvasGroup panelLevelSelection;
    [SerializeField] private Button buttonBackToMain;

    [SerializeField] private Transform levelsParent;
    [SerializeField] private GameObject prefabLevelButton;

    void Start()
    {
        buttonNewGame.onClick.AddListener(LoadFirstLevel);
        buttonLevelSelection.onClick.AddListener(ShowLevelSelection);
        buttonExit.onClick.AddListener(ExitGame);
        buttonBackToMain.onClick.AddListener(ShowMain);


        int i = 0;
        foreach(SceneReference levels in GameManager.Instance.sceneLevel)
        {
           Button button = Instantiate(prefabLevelButton, levelsParent).GetComponent<Button>();
            button.GetComponentInChildren<TextMeshPro>().text = levels.Name;
            int currentIndex = i;
            button.onClick.AddListener(() =>
            {
                GameManager.Instance.LoadLevel(currentIndex);
            });
            i++;
        }


        ShowMain();  
    }

    void ShowLevelSelection()
    {
        panelLevelSelection.ShowCanvasGroup();
        panelMain.HideCanvasGroup();
    }

    void ShowMain()
    {
        panelLevelSelection.HideCanvasGroup();
        panelMain.ShowCanvasGroup();
    }

    void LoadFirstLevel()
    {
        GameManager.Instance.LoadLevel(listIndex: 0);
    }

    void ExitGame()
    {
        Application.Quit();
    }
    
}
