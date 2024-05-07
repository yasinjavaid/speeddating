using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SWS;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
	
	public enum Interest 
	{
		male,
		female,
		both
	}
	
	public GameObject dragObject;
	public InputManager inputManager;
	public UIManager uiManager;
	public PathManager originalPath,skipPath;
	public DialogueSystem dialogueSystem;
	public CustomersManager customersManager;
	public CameraManager camManager;
	public Camera Cam;
	public int CurrentPatientVariation = 0;
	public bool isBestVaccineCreated { get; set; }
	public int currentPatient { get; set; }
	public bool isHobbyPanel = false;
	public int correctStatmentAnswers,totalQustions;
	public int acceptedPlayers;
	public bool isFemale = false;
	public Interest playerPreference;
	public GameObject emojiHappy;
	public GameObject emojiAngry;
	#region likes
	public Sprite hobbyReading;
	public Sprite hobbyDogs;
	public Sprite hobbyBurger;
	public Sprite hobbyMoney;
	public Sprite hobbyMusic;
	public Sprite hobbyPizza;
	#endregion

	#region Proffession
	public Sprite professionPolice;
	public Sprite professionFireman;
	public Sprite professionBuilder;
	public Sprite professionDoctor;
	public Sprite professionChef;
	public Sprite professionTeacher;
	#endregion

	#region data
	public DaysManager days;
	public Characters characterData;
	public Questions questionsData;
	#endregion
	private void OnEnable()
    {
		SimpleAnimatorStatController.onFinish += AcceptReject;
    }
    private void Start()
	{
		currentPatient = 0;
		acceptedPlayers = 0;
		customersManager.acceptedPlayersList.Clear();
		//StartGame();
	}
	public void StartGame()
	{
		uiManager.DisableAllScreens();
		uiManager.ShowScreen(UIManager.UIScreens.LobbyUI);
		uiManager.overlayCanvas.SetActive(true);
		customersManager.StartPatientsInQueue();
	}
	public void StartVaccination()
	{
	}
	public void StartNextPatientsAtReception()
	{
		camManager.CameraGoToReception();
		uiManager.FadeIn(true);
		SetCameraFieldOfView(60, 0.5f, 0f);
	}
	public void SetCameraFieldOfView(int fov = 60, float time = 0, float delay = 0.1f, UnityAction onComplete = null)
	{
		Cam.DOFieldOfView(fov, time).SetEase(Ease.OutSine).SetDelay(delay).OnComplete(() => { onComplete?.Invoke(); });
	}
	public void ReloadScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void AcceptReject(bool accept) 
	{
		if (accept)
			customersManager.patientsList[0].ResumePathforAccept();
		else
			customersManager.patientsList[0].RejectPath();
	}
    private void OnDisable()
    {
		SimpleAnimatorStatController.onFinish -= AcceptReject;
	}
	public void OpenTextingPanel() 
	{
	//	uiManager.textingPanel.GetCurrentDate(customersManager.patientsList[0]);
	}
	public void nextDay() 
	{
		days.currentDay++;
		if (days.currentDay >= 3)
		{
			SceneManager.LoadScene("GameScene");
		}
		else 
		{
			uiManager.DisableAllScreens();
			uiManager.ShowScreen(UIManager.UIScreens.StartUI);
			ResetForDay();
		}
	
	}
	public void ResetForDay() 
	{
		acceptedPlayers = 0;
		customersManager.acceptedPlayersList.Clear();
		correctStatmentAnswers = 0;
	}
}
