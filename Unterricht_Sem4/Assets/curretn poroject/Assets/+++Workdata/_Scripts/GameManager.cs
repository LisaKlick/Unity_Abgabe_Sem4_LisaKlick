using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField] private SceneReference sceneMenu;
    public SceneReference[] sceneLevel;
 
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(sceneMenu.BuildIndex);
    }

    public void LoadLevel(int listIndex)
    {
        SceneManager.LoadScene(sceneLevel[listIndex].BuildIndex);
    }
   
   
}
