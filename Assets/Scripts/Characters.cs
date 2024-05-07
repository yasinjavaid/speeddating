using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum CharactersNameEnum
{
    John,
    Jack,
    James,
    Tom,
    Micheal,
    Steven,
    Doug,
    Adam,
    Tims,
    Terry,
    Robert,
    Miguel,
    George,
    Leonard,
    Martin,
    Luke,
    Bob,
    Diego,
    Peter,
    Clark,
    Shawn,
    Jenna,
    Lily,
    Lisa,
    Rachel,
    Sasha,
    Audrey,
    Diana,
    Martha,
    Jessica,
    Megan,
    Monica,
    Eve,
    Amy,
    Gina,
    Bella,
    Lucy,
    Stella,
    Ava,
    Sophia,
    Mary,
    Michelle,
    Amber,
    Mira,
    Grace
}
public enum CharacterGenderEnum
{
    Male,
    Female,
    None
}
public enum HobbiesEnum
{
    Books,
    Pets,
    Food,
    Money,
    Music,
    Pizza,
    none
}
public enum ProfessionEnum
{
    Policeman,
    Fireman,
    Builder,
    Doctor,
    Chef,
    Teacher,
    none
}
[Serializable]
public struct CharactersStruct
{
    public CharactersNameEnum name;
    public int age;
    public ProfessionEnum profession;
    public HobbiesEnum likes;
    public CharacterGenderEnum gender;
}
public class Characters : MonoBehaviour
{
    public List<CharactersStruct> playersList;
    /// <summary>
    ///     when called returns the PlayerData of that player by their name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public CharactersStruct GetPlayerDataFromName(CharactersNameEnum name) 
    {
        for (int i = 0; i < playersList.Count; i++)
        {
            if (playersList[i].name == name)
            {
                return playersList[i];
            }
        }
        return new CharactersStruct();
    }
}
