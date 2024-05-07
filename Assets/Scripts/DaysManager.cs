using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Days
{
    public ProfessionEnum profession;
    public HobbiesEnum likes;
    public bool isAge;
    public int age;
    public List<CharactersNameEnum> characters;

}
public class DaysManager : MonoBehaviour
{
    [HideInInspector]
    public int currentDay = 0; 
    public GameManager gameManager;
    public List<Days> MaleDays;
    public List<Days> FemaleDays;
    public List<Days> BothDays;
    public Days GetCurrentDayData() 
    {
        if (gameManager.playerPreference == GameManager.Interest.male)
        {
            return MaleDays[currentDay];
        }
        else if (gameManager.playerPreference == GameManager.Interest.female)
        {
            return FemaleDays[currentDay];
        }
        else if (gameManager.playerPreference == GameManager.Interest.both)
        {
            return BothDays[currentDay];
        }
        return MaleDays[currentDay];
    }
    // Start is called before the first frame update
}

