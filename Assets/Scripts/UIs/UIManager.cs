using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    
    public GameManager GameManager;
    public Animator preferenceMale, preferenceFemale;
    public GameObject overlayCanvas;
    // Start is called before the first frame update
    public GameObject PreferenceUI;
    public GameObject StartUI;
    public GameObject MobileUI;
    public Lobby LobbyUI;
    public GameObject ChatSelectionUI;
    public GameObject ChatResultUI;
    public Lab_UI LabUI;
    public Shot_UI Shot_UI;
    public HobbyPanel hobbyPanel;
    public TextingPanel textingPanel;
    public Image FinalPanel;
    public enum UIScreens
    {
        PreferenceUI,
        StartUI,
        LobbyUI,
        MobileUI,
        ChatSelectionUI,
        LabUI,
        ChatResultsUI,
        ShotUI
    }
    void Start()
    {
        
    }
    public void ShowScreen(UIScreens screen) 
    {
        //DisableAllScreens();
        switch (screen)
        {
            case UIScreens.PreferenceUI:
                PreferenceUI.gameObject.SetActive(true);
                break;
            case UIScreens.StartUI:
                StartUI.gameObject.SetActive(true);
                break;
            case UIScreens.LobbyUI:
                LobbyUI.gameObject.SetActive(true);
                break;
            case UIScreens.MobileUI:
                MobileUI.SetActive(true);
                break;
            case UIScreens.ChatSelectionUI:
                ChatSelectionUI.gameObject.SetActive(true);
                break;
            case UIScreens.ChatResultsUI:
                ChatResultUI.gameObject.SetActive(true);
                break;
            case UIScreens.LabUI:
                LabUI.gameObject.SetActive(true);
                break;
            case UIScreens.ShotUI:
                Shot_UI.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void DisableAllScreens() 
    {
        PreferenceUI.gameObject.SetActive(false);
        ChatResultUI.SetActive(false);
        LobbyUI.gameObject.SetActive(false);
        StartUI.SetActive(false);
        MobileUI.SetActive(false);
        ChatSelectionUI.SetActive(false);
        textingPanel.ParentObject.SetActive(false);
      //  LabUI.gameObject.SetActive(false);
      //  Shot_UI.gameObject.SetActive(false);
    }
    public void FadeIn(bool isLab) 
    {
        FinalPanel.gameObject.SetActive(true);
        FinalPanel.DOFade(0.95f,1f).OnComplete( () => 
        {
         
            FadeOut();
        }
        ).SetAutoKill(true);
    }
    public void FadeOut() 
    {
        FinalPanel.DOFade(0f,1f).OnComplete(() =>
        { 
            FinalPanel.gameObject.SetActive(false);
            GameManager.customersManager.StartPatientsInQueue();
         
        }
        ).SetAutoKill(true);

    }
    public void onGenderSelect(bool isFemale)
    {
        if (isFemale)
        {
            GameManager.isFemale = true;
            preferenceMale.gameObject.SetActive(false);
            preferenceFemale.transform.eulerAngles = Vector3.zero;
            preferenceFemale.SetTrigger("Select");
            preferenceFemale.transform.DOLocalMoveX(31,1).SetAutoKill(true);
        }
        else
        {
            GameManager.isFemale = false;
            preferenceFemale.gameObject.SetActive(false);
            preferenceMale.transform.eulerAngles = Vector3.zero;
            preferenceMale.SetTrigger("Select");
            preferenceMale.transform.DOLocalMoveX(-50, 1).SetAutoKill(true);
        }
    }
    public void SelectPreference(int i) 
    {
        switch (i)
        {
            case 1:
                GameManager.playerPreference = GameManager.Interest.male;
                break;
            case 2:
                GameManager.playerPreference = GameManager.Interest.female;
                break;
            case 3:
                GameManager.playerPreference = GameManager.Interest.both;
                break;
            default:
                break;
        }
        DisableAllScreens();
        ShowScreen(UIScreens.StartUI);
    }
   
}
