using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;
using DG.Tweening;

public class Customers : MonoBehaviour
{      
    [HideInInspector]
    public CharactersStruct personalInfo;
    #region Animator parameters
    [Header("Animator Attributes")]
    [SerializeField] private string animBoolIdle = "";
    [SerializeField] private string animBoolWalking = "";
    [SerializeField] private string animBoolDrunk = "";
    [SerializeField] private string animBoolWaving = "";
    [SerializeField] private string animBoolLeftPunch = "";
    [SerializeField] private string animHappy = "";
    [SerializeField] private string animAngry = "";
    #endregion
    public GameManager gameManager;
    [SerializeField] private splineMove splineMove;
  //  [SerializeField] private PatientVariations patientVariations;

    public bool isPathStart = false;
    public Sprite diseaseEmoji;
    public Animator anim;
    [HideInInspector]
    public int pointToStop;
    public int currentQ { get; set; }
    // Start is called before the first frame update
    private void Awake()
    {
        if (splineMove == null)
        {
            splineMove = GetComponent<splineMove>();
        }
        splineMove.OnReachReception += OnReachCounter;
        currentQ = 0;
    }
    public void StartPath()
    {
        splineMove.StartMove();
        anim.SetBool(animBoolWalking, true);
        isPathStart = true;
    }
    public void OnReachCounter(int pathPointIndex = -1)
    {
        pathPointIndex -= 1;
        if (pathPointIndex == pointToStop)
        {
            splineMove.Pause();
            anim.SetBool(animBoolWalking, false);
           
            if (pointToStop == gameManager.customersManager.counterIndex)
            {
                //    gameManager.CurrentPatientVariation = patientVariations.CurrentPlayer;
                //   anim.SetBool(animBoolDrunk, true);
                UpdateInfoOnHobbyPanel();
                splineMove.OnReachReception -= OnReachCounter;
            }
        }
    }
    public void ResumePathforAccept()
    {
        if (CheckPerfectMatch(gameManager.days.GetCurrentDayData()))
        {
            gameManager.uiManager.LobbyUI.ShowStarts(++gameManager.acceptedPlayers);
            gameManager.customersManager.acceptedPlayersList.Add(this.gameObject.GetComponent<Customers>());
        }
        else 
        {
          
        }
        anim.SetBool(animBoolWalking,   true);
        splineMove.Resume();
        CallNextPlayer();
    }
    public void RejectPath() 
    {
        anim.SetBool(animBoolWalking, false);
        anim.SetBool(animBoolWalking, true);
        splineMove.SetPath(gameManager.skipPath);
        splineMove.StartMove();
        CallNextPlayer();
    }
    private void CallNextPlayer() 
    {
        StartCoroutine(gameManager.customersManager.RemovePlayerFromTop(1));
    }
    private void UpdateInfoOnHobbyPanel()
    {
        gameManager.uiManager.hobbyPanel.setPlayerInfoOnHobbyPanel(personalInfo);
        gameManager.dragObject.SetActive(true);
        gameManager.isHobbyPanel = true;
        gameManager.uiManager.ShowScreen(UIManager.UIScreens.MobileUI);
        gameManager.dragObject.SetActive(true);
        //  gameManager.dialogueSystem.UpdateQuestions();
    }
    private void OnDisable()
    {
        ReSetting();
    }
    private void ReSetting() 
    {
        splineMove.OnReachReception -= OnReachCounter;
    }
    public void Accept() 
    {
        gameManager.emojiHappy.SetActive(false);
        anim.SetTrigger(animHappy);
        gameManager.emojiHappy.SetActive(true);
        gameManager.uiManager.hobbyPanel.Heart.transform.DOScale(0.05f, 0).SetAutoKill(true);
        gameManager.uiManager.hobbyPanel.Heart.SetActive(true);
        gameManager.uiManager.hobbyPanel.Heart.transform.DOScale(0.1f,1).SetEase(Ease.OutElastic).SetAutoKill(true);
        
        //ResumePathforAccept();
      //  Invoke("offMobileScreen", 0.5f);
    }
    public void Reject() 
    {
        gameManager.emojiAngry.SetActive(false);
        anim.SetTrigger(animAngry);
        gameManager.emojiAngry.SetActive(true);
        gameManager.uiManager.hobbyPanel.Cross.transform.DOScale(0.05f, 0).SetAutoKill(true);
        gameManager.uiManager.hobbyPanel.Cross.SetActive(true);
        gameManager.uiManager.hobbyPanel.Cross.transform.DOScale(0.1f, 1).SetEase(Ease.OutElastic).SetAutoKill(true);

        Handheld.Vibrate();
        //RejectPath();
        //   Invoke("offMobileScreen",0.5f);
    }
    public void offMobileScreen() 
    {
        gameManager.uiManager.MobileUI.SetActive(false);
    } 
    public bool CheckPerfectMatch(Days AccecptData)
    {
        var isPerfectProfession = false;
        var isPerfectLike = false;
        var isPerfectAge = false;
        if (personalInfo.profession == AccecptData.profession)
        {
            isPerfectProfession = true;
        }
        if (personalInfo.likes == AccecptData.likes)
        {
            isPerfectLike = true;
        }
        if (AccecptData.isAge && personalInfo.age >= AccecptData.age)
        {
            isPerfectAge = true;
        }
        if (!AccecptData.isAge)
        {
            isPerfectAge = true;
        }
        if (isPerfectAge && isPerfectLike && isPerfectProfession)
        {
            return true;
        }
        else
        {
            return false;
        }
          return false;

    }
}
