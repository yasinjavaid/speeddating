using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shot_UI : MonoBehaviour
{
    [SerializeField] private GameObject SelectScreen;
    [SerializeField] private GameObject FinalScreen;
    [SerializeField] private  GameObject[] BubbleVaccinesTypes;
    [SerializeField] private RectTransform wrongVaccineButton;


    // Start is called before the first frame update

    public void ActiveBubbleVaccine(int no)
    {
        for (int i = 0; i < BubbleVaccinesTypes.Length; i++)
        {
            BubbleVaccinesTypes[i].SetActive(false);
        }
        switch (no)
        {
            case 1:
                BubbleVaccinesTypes[0].SetActive(true); 
                break;
            case 2:
                BubbleVaccinesTypes[1].SetActive(true);
                break;
            case 3:
                BubbleVaccinesTypes[2].SetActive(true);
                break;
            case 4:
                BubbleVaccinesTypes[3].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void SetWrongVaccine(int no)
    {
        switch (no)
        {
            case 1:
                wrongVaccineButton.gameObject.SetActive(true);
                wrongVaccineButton.anchoredPosition = new Vector2(-200,4);
                break;
            case 2:
                wrongVaccineButton.gameObject.SetActive(true);
                wrongVaccineButton.anchoredPosition = new Vector2(0, 4);
                break;
            case 3:
                wrongVaccineButton.gameObject.SetActive(true);
                wrongVaccineButton.anchoredPosition = new Vector2(200, 4);
                break;
            default:
                break;
        }
    }
    public void hideMainScreen()
    {
        SelectScreen.SetActive(false);
    }
    public void ActiveFinalScreen()
    {
        SelectScreen.SetActive(false);
        FinalScreen.SetActive(true);
    }
    public void ResetUI()
    {
        wrongVaccineButton.gameObject.SetActive(false);
        SelectScreen.SetActive(true);
        FinalScreen.SetActive(false);
    }
}
