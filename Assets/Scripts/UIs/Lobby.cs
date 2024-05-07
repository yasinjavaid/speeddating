using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class Lobby : MonoBehaviour
{
    public GameObject acceptPanel; 
    public Image profession;
    public Image likesImage;
    public TextMeshProUGUI age;
    public GameObject Likes;
    public GameManager gameManager;
    public GameObject[] hearts;
    public Image heartsFillBar;
    // Start is called before the first frame update
    private void OnEnable()
    {
        #region profession display

        heartsFillBar.fillAmount = 0;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].transform.localScale = Vector3.zero;
        }
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
                acceptPanel.transform.DOLocalMoveX(35, 0.1f).SetAutoKill(true);
            }
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
                acceptPanel.transform.DOLocalMoveX(35, 0.1f).SetAutoKill(true);
            }
            ShowSpriteProfessionStartScreen(gameManager.days.FemaleDays[gameManager.days.currentDay].profession);
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
                acceptPanel.transform.DOLocalMoveX(35,0.1f).SetAutoKill(true);
            }
            ShowSpriteProfessionStartScreen(gameManager.days.BothDays[gameManager.days.currentDay].profession);
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
    public void ShowStarts(int i)
    {
        switch (i)
        {
            case 1:
                hearts[0].SetActive(true);
                hearts[0].transform.DOScale(1,0.5f).SetEase(Ease.InSine).SetAutoKill(true);
                heartsFillBar.fillAmount = 0.2f;
                break;
            case 2:
                hearts[1].SetActive(true);
                hearts[1].transform.DOScale(1, 0.5f).SetEase(Ease.InSine).SetAutoKill(true);
                heartsFillBar.fillAmount = 0.5f;
                break;
            case 3:
                hearts[2].SetActive(true);
                hearts[2].transform.DOScale(1, 0.5f).SetEase(Ease.InSine).SetAutoKill(true);
                heartsFillBar.fillAmount = 1f;
                break;
            default:
                break;
        }
    }
}
