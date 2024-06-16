using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel : MonoBehaviour
{
   //For the start panel to work with it/ linking (?)

    [Header("PanelStart")]
    [SerializeField] private CanvasGroup panelStart;
    [SerializeField] private Button buttonStartLevel;

    //For the winning panel

    [Header("PanelWin")]
    [SerializeField] private CanvasGroup panelWin;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private Button buttonAgain1;
    [SerializeField] private Button buttonBackToMenu1;

    //Fot the Lose panel

    [Header("PanelLose")]
    [SerializeField] private CanvasGroup panelLose;
    [SerializeField] private Button buttonAgain2;
    [SerializeField] private Button buttonBackToMenu2;

    void Start()
    {
        //that the losing and winning panels are hid during the game
        panelWin.HideCanvasGroup();
        panelLose.HideCanvasGroup();

        buttonStartLevel.onClick.AddListener(() =>
        {
            panelStart.HideCanvasGroup();
            GameController.Instance.StartLevel();
        });
        //for loading levels and/ or menu

        buttonAgain1.onClick.AddListener(GameController.Instance.ReloadLevel);
        buttonAgain2.onClick.AddListener(GameController.Instance.ReloadLevel);
        buttonBackToMenu1.onClick.AddListener(GameController.Instance.LoadMenu);
        buttonBackToMenu2.onClick.AddListener(GameController.Instance.LoadMenu);

        buttonNextLevel.onClick.AddListener(GameController.Instance.LoadNextLevel);
    }

    //When the player wins winning panel show up
    public void ShowWinScreen()
    {
        panelWin.ShowCanvasGroup();
    }

    //When the player loses losing panel show up
    public void ShowLoseScreen()
    {
        panelLose.ShowCanvasGroup();
    }
}
