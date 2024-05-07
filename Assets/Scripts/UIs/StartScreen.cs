using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartScreen : MonoBehaviour
{
    public GameObject acceptMiniPanel;
    public Image profession;
    public Image likesImage;
    public TextMeshProUGUI age,daysText;
    public GameObject Likes;
    public GameManager gameManager;
    // Start is called before the first frame update
    private void OnEnable()
    {
        #region profession display

        daysText.text = "Day " + (gameManager.days.currentDay +1); 
        if (gameManager.playerPreference == GameManager.Interest.male)
        {
            ShowSpriteProfessionStartScreen(gameManager.days.MaleDays[gameManager.days.currentDay].profession);
            if (gameManager.days.MaleDays[gameManager.days.currentDay].likes != HobbiesEnum.none)
            {
             
                ShowHobbyIcon(gameManager.days.MaleDays[gameManager.days.currentDay].likes);
            }
            if (gameManager.days.MaleDays[gameManager.days.currentDay].isAge)
            {
                age.text = gameManager.days.MaleDays[gameManager.days.currentDay].age + "+";
                acceptMiniPanel.transform.DOLocalMoveX(-86, 0).SetAutoKill(true);
            }
            gameManager.customersManager.CreatePlayersForDay(gameManager.days.MaleDays[gameManager.days.currentDay]);
        }
        if (gameManager.playerPreference == GameManager.Interest.female)
        {
            if (gameManager.days.FemaleDays[gameManager.days.currentDay].likes != HobbiesEnum.none)
            {
                ShowHobbyIcon(gameManager.days.FemaleDays[gameManager.days.currentDay].likes);
            }
            if (gameManager.days.FemaleDays[gameManager.days.currentDay].isAge)
            {
                age.text = gameManager.days.FemaleDays[gameManager.days.currentDay].age + "+";
                acceptMiniPanel.transform.DOLocalMoveX(-86, 0).SetAutoKill(true);
            }
            ShowSpriteProfessionStartScreen(gameManager.days.FemaleDays[gameManager.days.currentDay].profession);
            gameManager.customersManager.CreatePlayersForDay(gameManager.days.FemaleDays[gameManager.days.currentDay]);
        }
        if (gameManager.playerPreference == GameManager.Interest.both)
        {
            if (gameManager.days.BothDays[gameManager.days.currentDay].likes != HobbiesEnum.none)
            {
                ShowHobbyIcon(gameManager.days.BothDays[gameManager.days.currentDay].likes);
            }
            if (gameManager.days.BothDays[gameManager.days.currentDay].isAge)
            {
                age.text = gameManager.days.BothDays[gameManager.days.currentDay].age + "+";
                acceptMiniPanel.transform.DOLocalMoveX(-86, 0).SetAutoKill(true);
            }
            ShowSpriteProfessionStartScreen(gameManager.days.BothDays[gameManager.days.currentDay].profession);
            gameManager.customersManager.CreatePlayersForDay(gameManager.days.BothDays[gameManager.days.currentDay]);
        }
        #endregion

    }
    public void ShowHobbyIcon(HobbiesEnum likes)
    {
        Likes.SetActive(true);
        switch (likes)
        {
            case HobbiesEnum.Books:
                likesImage.sprite = gameManager.hobbyReading;
                break;
            case HobbiesEnum.Pets:
                likesImage.sprite = gameManager.hobbyDogs;
                break;
            case HobbiesEnum.Food:
                likesImage.sprite = gameManager.hobbyBurger;
                break;
            case HobbiesEnum.Money:
                likesImage.sprite = gameManager.hobbyMoney;
                break;
            case HobbiesEnum.Music:
                likesImage.sprite = gameManager.hobbyMusic;
                break;
            case HobbiesEnum.Pizza:
                likesImage.sprite = gameManager.hobbyPizza;
                break;
            default:
                break;
        }
    }
    public void ShowSpriteProfessionStartScreen(ProfessionEnum professionForAccept) 
    {
        switch (professionForAccept)
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
            default:
                break;
        }
    }
}
