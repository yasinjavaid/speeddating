using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CamBoundries
{
    public float[] xLimits;
    public float[] yLimits;
    public float[] zLimits;
}
public class LevelManager : MonoBehaviour
{
    [HideInInspector]
    public int totalEnemiesInLevel;
    [HideInInspector]
    public int totalVanishedEnemies;

    public CamBoundries camBoundries;
    void Start()
    {
        totalEnemiesInLevel = 0;
        totalVanishedEnemies = 0;
    }

    
}
