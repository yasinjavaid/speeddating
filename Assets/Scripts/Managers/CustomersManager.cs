using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SWS;

public class CustomersManager : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    public GameObject BuilderMalePrefab;
    public GameObject PolicemanMalePrefab;
    public GameObject FireManMalePrefab;
    public GameObject DoctorFemalePrefab;
    public GameObject ChefFemalePrefab;
    public GameObject TeacherFemalePrefab;
    public Transform instantiatePos;
    public List<Customers> patientsList = new List<Customers>();
    public int counterIndex = 4;
    [HideInInspector]
    public int patientCounter = 0;
    [HideInInspector]
    public List<Customers> acceptedPlayersList;
    public void CreatePlayersForDay(Days dataforthatday) 
    {
        for (int i = 0; i < dataforthatday.characters.Count; i++)
        {
            var playerData = gameManager.characterData.GetPlayerDataFromName
                (dataforthatday.characters[i]);
            switch (playerData.profession)
            {
                case ProfessionEnum.Policeman:
                    createPlayer(PolicemanMalePrefab,playerData);
                    break;
                case ProfessionEnum.Fireman:
                    createPlayer(FireManMalePrefab, playerData);
                    break;
                case ProfessionEnum.Builder:
                    createPlayer(BuilderMalePrefab, playerData);
                    break;
                case ProfessionEnum.Doctor:
                    createPlayer(DoctorFemalePrefab, playerData);
                    break;
                case ProfessionEnum.Chef:
                    createPlayer(ChefFemalePrefab, playerData);
                    break;
                case ProfessionEnum.Teacher:
                    createPlayer(TeacherFemalePrefab, playerData);
                    break;
                case ProfessionEnum.none:
                    break;
                default:
                    break;
            }
        }
    }
    public void StartPatientsInQueue()
    {
        if (patientsList.Count == 0)
            return;
        var points = counterIndex;
        patientsList[0].pointToStop = points;
        if (!patientsList[0].isPathStart)
        {
            patientsList[0].StartPath();
        }
        foreach (var patient in patientsList)
        {
            patient.pointToStop = points;

        }
        /* foreach (var patient in patientsList)
         {
             patient.pointToStop = points;
             points--;
             if (!patient.isPathStart)
             {
                 patient.StartPath();
             }
             else
             {
                 patient.ResumePathforAccept();
             }
         }*/

    }
  
    public IEnumerator RemovePlayerFromTop(float t = 0) 
    {
        yield return new WaitForSeconds(t);
        patientCounter++;
        patientsList.RemoveAt(0);
        if (patientsList.Count <= 0)
        {
            if (gameManager.acceptedPlayers > 0)
            {
                gameManager.uiManager.overlayCanvas.SetActive(false);
                gameManager.uiManager.ShowScreen(UIManager.UIScreens.ChatSelectionUI);
            }
            else
            {
                gameManager.uiManager.overlayCanvas.SetActive(false);
                gameManager.uiManager.DisableAllScreens();
                gameManager.uiManager.ShowScreen(UIManager.UIScreens.ChatResultsUI);
            }
            
        }
        else
        {
            StartPatientsInQueue();
        }
    }
    public void RemovePatientFromTop(bool isWrongAnswer) 
    {
        patientCounter++;
        patientsList.RemoveAt(0);

        if (isWrongAnswer)
        {
            gameManager.camManager.CameraGoToLabAnim();
        }
        else
        {
            StartPatientsInQueue();
        }
        //StartPatientsInQueue(); //Call on complete of vaccination
    }
    public void createPlayer(GameObject go, CharactersStruct info) 
    {
        var tempObj = Instantiate(go) as GameObject;
        var splinemove = tempObj.GetComponent<splineMove>();
        var customers = tempObj.GetComponent<Customers>();
        tempObj.transform.localPosition = instantiatePos.localPosition;
        splinemove.SetPath(gameManager.originalPath,false);
        customers.gameManager = gameManager;
        customers.personalInfo = info;
        patientsList.Add(customers);
    }
}
