using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct QuestionStruct 
{
    public string Question;
    public string Replay;
}
public class Questions : MonoBehaviour
{
    public List<QuestionStruct> correctQ;
    public List<QuestionStruct> wrongQ;
    public List<QuestionStruct> GetRandomCorrectQuestions(int noOfQ) 
    {
        List<QuestionStruct> templist = new List<QuestionStruct>();
        List<int> forRandom = new List<int>();
        List<int> RandomNumbers = new List<int>();
        for (int i = 0; i < correctQ.Count; i++)
        {
            forRandom.Add(i);
        }
        for (int i = 0; i < noOfQ; i++)
        {
            var b = UnityEngine.Random.Range(0, forRandom.Count);
            RandomNumbers.Add(forRandom[b]);
            forRandom.Remove(b);
        }
        for (int i = 0; i < RandomNumbers.Count; i++)
        {
            templist.Add(correctQ[RandomNumbers[i]]);
        }
        return templist;
    }
    public List<QuestionStruct> GetRandomWrongQuestions(int noOfQ)
    {
        List<QuestionStruct> templist = new List<QuestionStruct>();
        List<int> forRandom = new List<int>();
        List<int> RandomNumbers = new List<int>();
        for (int i = 0; i < wrongQ.Count; i++)
        {
            forRandom.Add(i);
        }
        for (int i = 0; i < noOfQ; i++)
        {
            var b = UnityEngine.Random.Range(0, forRandom.Count);
            RandomNumbers.Add(forRandom[b]);
            forRandom.Remove(b);
        }
        for (int i = 0; i < RandomNumbers.Count; i++)
        {
            templist.Add(wrongQ[RandomNumbers[i]]);
        }
        return templist;
    }
}
