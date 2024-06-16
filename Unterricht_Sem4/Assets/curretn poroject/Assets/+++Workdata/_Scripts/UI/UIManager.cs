using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelLost;

    [SerializeField] private Button buttonTryAgain;
    // Start is called before the first frame update
    void Start()
    {
        panelLost.SetActive(false);
        Time.timeScale = 1f;
        
        buttonTryAgain.onClick.AddListener(ReloadCurrentLevel);
    }

    public void ShowLostPanel()
    {
        panelLost.SetActive(true);
        Time.timeScale = 0f;
    }

    void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
