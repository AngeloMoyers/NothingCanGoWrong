using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;

    private void Awake()
    {
        WinScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public void CloseWinScreen()
    {
        WinScreen.SetActive(false);
    }

    public void NextLevel()
    {
        //TODO
    }
}
