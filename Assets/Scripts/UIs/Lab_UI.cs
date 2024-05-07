using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lab_UI : MonoBehaviour
{
    [SerializeField] private GameObject mainSceen;
    [SerializeField] private GameObject FinalScreen;
    [SerializeField] private TextMeshProUGUI finalText;
    [SerializeField] private GameObject[] lastPanelButtons;

    // Start is called before the first frame update

    public void hideMainScreen()
    {
        mainSceen.SetActive(false);
    }
    public void ActiveFinalScreen() 
    {
        mainSceen.SetActive(false);
        FinalScreen.SetActive(true);
    }
    public void SuccessLastPanel(bool yes)
    {
        if (yes)
        {
            lastPanelButtons[0].SetActive(true);
            lastPanelButtons[1].SetActive(false);
            lastPanelButtons[2].SetActive(false);
            finalText.text = "Yay! Vaccine created.";
        }
        else 
        {
            lastPanelButtons[0].SetActive(false);
            lastPanelButtons[1].SetActive(true);
            lastPanelButtons[2].SetActive(true);
            finalText.text = "Wrong vaccine created, continue process?";
        }
    }
    public void ResetUI() 
    {
        mainSceen.SetActive(true);
        FinalScreen.SetActive(false);
        lastPanelButtons[0].SetActive(true);
        lastPanelButtons[1].SetActive(false);
        lastPanelButtons[2].SetActive(false);
    }
    
}
