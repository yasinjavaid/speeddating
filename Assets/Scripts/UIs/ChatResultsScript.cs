using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ChatResultsScript : MonoBehaviour
{
    public GameObject[] starts;
    public float delay;
    public GameManager gameManager;
    public TextMeshProUGUI results,resultsText;
    public GameObject VictoryEffect;
    private int counter = 0;
    private void OnEnable()
    {
        foreach (var item in starts)
        {
            item.SetActive(false);
        }

        if (gameManager.acceptedPlayers <= 0)
        {
            results.text = "Match not found";
            results.transform.localPosition = new Vector3
                (results.transform.localPosition.x,
                0,
                results.transform.localPosition.z);
            resultsText.text = "Day " + (gameManager.days.currentDay +1);
        }
        else
        {
            results.transform.localPosition = new Vector3
            (results.transform.localPosition.x,
            -50,
            results.transform.localPosition.z);
            results.text = gameManager.correctStatmentAnswers + " / " + gameManager.totalQustions;
            foreach (var item in starts)
            {
                item.SetActive(false);
            }
            switch (gameManager.correctStatmentAnswers)
            {
                case 1:
                    resultsText.text = "Disastrous match";
                    break;
                case 2:
                    resultsText.text = "Bad match";
                    break;
                case 3:
                    resultsText.text = "Okay match";
                    break;
                case 4:
                    resultsText.text = "Good match";
                    break;
                case 5:
                    resultsText.text = "Perfect match";
                    break;
                default:
                    break;
            }
            StartCoroutine(activeStarts(gameManager.correctStatmentAnswers));
        }
        
    }
    private IEnumerator activeStarts(int correct) 
    {
        while (counter < correct)
        {
            starts[counter].SetActive(true);
            counter++;
            yield return new WaitForSeconds(delay);
        }

        VictoryEffect.SetActive(true);
    }
    private void OnDisable()
    {
        counter = 0;
        VictoryEffect.SetActive(false);
    }
}
