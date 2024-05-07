using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Lean.Touch;

public class HobbyPanel : MonoBehaviour
{

    #region public 
 
    [HideInInspector]
    public bool isHobby = false;
    public bool isAccept;
    public bool isReject;
    #endregion
    #region	  Private 
    private Vector2 dragValue;
    private float DragDis;
    private Tween tween;
    private bool isFingerDown = false;
    #endregion
    public Transform HandForTilt;
    public GameObject parentobject;
    public GameManager gameManager;
    public Text nameNage;
    public Image like, profession, placeHolder;
    public Image AcceptArrow, RejectArrow;
    public GameObject Heart, Cross; 
    // Start is called before the first frame update

    private void OnEnable()
    {
        LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
     /*  HandForTilt
               .DOLocalRotate(new Vector3(0, 0, 30), 1)
               .SetAutoKill(true);*/
    }

    public void setPlayerInfoOnHobbyPanel(CharactersStruct info)
    {
        AcceptArrow.DOFade(0,0);
        RejectArrow.DOFade(0,0);
        AcceptArrow.gameObject.SetActive(true);
        RejectArrow.gameObject.SetActive(true);
        nameNage.text = info.name.ToString().ToUpper() + ", " + info.age;
       // placeHolder.sprite = info.playerPotrait;
        RejectArrow.DOFade(0, 0f);
        AcceptArrow.DOFade(0, 0f);
        placeHolder.DOFade(1,0);
        Heart.SetActive(false);
        Cross.SetActive(false);
        switch (info.likes)
        {
            case HobbiesEnum.Books:
                like.sprite = gameManager.hobbyReading;
                break;
            case HobbiesEnum.Pets:
                like.sprite = gameManager.hobbyDogs;
                break;
            case HobbiesEnum.Food:
                like.sprite = gameManager.hobbyBurger;
                break;
            case HobbiesEnum.Money:
                like.sprite = gameManager.hobbyMoney;
                break;
            case HobbiesEnum.Music:
                like.sprite = gameManager.hobbyMusic;
                break;
            case HobbiesEnum.Pizza:
                like.sprite = gameManager.hobbyPizza;
                break;
            default:
                break;
        }
        switch (info.profession)
        {
            case ProfessionEnum.Policeman:
                profession.sprite = gameManager.professionPolice;
                break;
            case ProfessionEnum.Fireman:
                profession.sprite = gameManager.professionFireman;
                break;
            case ProfessionEnum.Builder:
                profession.sprite = gameManager.professionBuilder;
                break;
            case ProfessionEnum.Doctor:
                profession.sprite = gameManager.professionDoctor;
                break;
            case ProfessionEnum.Chef:
                profession.sprite = gameManager.professionChef;
                break;
            case ProfessionEnum.Teacher:
                profession.sprite = gameManager.professionTeacher;
                break;
            case ProfessionEnum.none:
                break;
            default:
                break;
        }
    }

   
    private void LeanTouch_OnFingerDown(LeanFinger obj)
    {
        isFingerDown = true;
    }

    private void LeanTouch_OnFingerUp(LeanFinger obj)
    {
        if (!gameManager.isHobbyPanel)
            return;
        isFingerDown = false;
        dragValue = Vector3.zero;
        DragDis = 0;
        gameManager.isHobbyPanel = false;
        gameManager.dragObject.SetActive(false);
        gameManager.isHobbyPanel = false;
        placeHolder.DOFade(1f, 0.1f);
        AcceptArrow.gameObject.SetActive(false);
        RejectArrow.gameObject.SetActive(false);
        HandForTilt.DOLocalMoveX(0, 0.3f).SetAutoKill(true);
        HandForTilt
              .DOLocalRotate(new Vector3(0, 0, 0), 1)
                 .SetAutoKill(true);
        if (isAccept)
        {
            gameManager.customersManager.patientsList[0].Accept();
        }
        else if (isReject)
        {
            gameManager.customersManager.patientsList[0].Reject();
        }
        else 
        {
            gameManager.isHobbyPanel = true;
            gameManager.dragObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isHobbyPanel)
        {
            if (dragValue.x >= 5f && DragDis >= 50)
            {
                if (!isAccept)
                {
                    AcceptArrow.DOFade(1f, 1f).OnComplete(() =>
                    {
                        RejectArrow.DOFade(0, 0.2f).SetAutoKill(true);
                    }).SetAutoKill(true);
                    RejectArrow.DOFade(0, 0.2f).SetAutoKill(true);
                    HandForTilt.DOLocalMoveX(100, 1).SetAutoKill(true);
                    HandForTilt
                     .DOLocalRotate(new Vector3(0, 0, -10), 1)
                     .SetAutoKill(true);
                }
                isAccept = true;
            }
            else
            {
                isAccept = false;
                //  gameManager.uiManager.hobbyPanel.AcceptArrow.SetActive(false);
            }
            if (dragValue.x <= -5f && DragDis >= 50)
            {
                if (!isReject)
                {
                    RejectArrow.DOFade(1f, 1f).OnComplete(() => 
                    {
                        AcceptArrow.DOFade(0, 0.2f).SetAutoKill(true);
                    }).SetAutoKill(true);
                    AcceptArrow.DOFade(0, 0.2f).SetAutoKill(true);
                    HandForTilt.DOLocalMoveX(-100, 1).SetAutoKill(true);
                    HandForTilt
                     .DOLocalRotate(new Vector3(0, 0, 10), 1)
                     .SetAutoKill(true);
                }
                isReject = true;
            }
            else
            {
                //   gameManager.uiManager.hobbyPanel.RejectArrow.SetActive(false);
                isReject = false;
            }
        }
        else
        {
           // gameManager.uiManager.hobbyPanel.RejectArrow.DOFade(0f, 0f);
           // gameManager.uiManager.hobbyPanel.AcceptArrow.DOFade(0, 0f);
        }
    }
    public void DragMove(Vector2 value)
    {
        dragValue = value;

    }
    public void DragDistance(float value)
    {
        DragDis = value;
    }
    private void OnDisable()
    {
        LeanTouch.OnFingerUp -= LeanTouch_OnFingerUp;
        LeanTouch.OnFingerDown -= LeanTouch_OnFingerDown;
    }
}
