using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private Scene menuScene;
    private void Awake()
    {
        GameManager.OnGameStateChanged += OnMenu;

    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnMenu;
    }

    private void OnMenu(GameState state)
    {
        if (state == GameState.MENU)
        {
            
        }
    }
}
