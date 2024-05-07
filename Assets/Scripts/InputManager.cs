using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using DG.Tweening;

public class InputManager : MonoBehaviour
{
    #region public 
    public GameManager gameManager;
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
    private void OnEnable()
    {
        LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
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
        gameManager.isHobbyPanel = false;
        gameManager.dragObject.SetActive(false);
        gameManager.isHobbyPanel = false;
        gameManager.uiManager.hobbyPanel.placeHolder.DOFade(1f, 0.1f);
        gameManager.uiManager.hobbyPanel.AcceptArrow.gameObject.SetActive(false);
        gameManager.uiManager.hobbyPanel.RejectArrow.gameObject.SetActive(false);
        if (isAccept)
        {      
            gameManager.customersManager.patientsList[0].Accept();
        }
        else if (isReject)
        {
            gameManager.customersManager.patientsList[0].Reject();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isHobbyPanel && isFingerDown)
        {    //accept
            if (dragValue.x >= 5f && DragDis >= 50 && !isAccept)
            {
                gameManager.uiManager.hobbyPanel.AcceptArrow.DOFade(1f, 1.5f);
                gameManager.uiManager.hobbyPanel.RejectArrow.DOFade(0, 0.5f);
                isAccept = true;
                gameManager.uiManager.hobbyPanel.HandForTilt
                    .DOLocalRotate(new Vector3(0,0,-30), 1)
                    .SetAutoKill(true);

            }
            else
            {
                isAccept = false;
                //  gameManager.uiManager.hobbyPanel.AcceptArrow.SetActive(false);
            }
            //reject
            if (dragValue.x <= -5f && DragDis >= 50 && !isReject)
            {
                gameManager.uiManager.hobbyPanel.RejectArrow.DOFade(1f, 1.5f);
                gameManager.uiManager.hobbyPanel.AcceptArrow.DOFade(0, 0.5f);
                isReject = true;
                Debug.Log("Reject");
                gameManager.uiManager.hobbyPanel.HandForTilt
                .DOLocalRotate(new Vector3(0, 0, 30), 1)
                .SetAutoKill(true);
            }
            else
            {
                //   gameManager.uiManager.hobbyPanel.RejectArrow.SetActive(false);
                isReject = false;
            }
        }
        else
        {
            gameManager.uiManager.hobbyPanel.RejectArrow.DOFade(0f, 0f);
            gameManager.uiManager.hobbyPanel.AcceptArrow.DOFade(0, 0f);
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

