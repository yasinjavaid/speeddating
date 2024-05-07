using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientVariations : MonoBehaviour
{
    [SerializeField] GameObject[] allPatients;
     [Range(1,22)] public int CurrentPlayer;
    // Start is called before the first frame update
    void Start()
    {
        SetMeshOfPatient(CurrentPlayer);
    }
    public void SetMeshOfPatient(int current) 
    {
        CurrentPlayer = current;
        for (int i = 1; i <= allPatients.Length; i++)
        {
            if (i == current)
            {
                allPatients[i-1].SetActive(true);
            }
            else
            {
                allPatients[i-1].SetActive(false);
            }
            

        }
    }
    public SkinnedMeshRenderer GetCurrentMesh() 
    {
        return allPatients[CurrentPlayer].GetComponent<SkinnedMeshRenderer>();
    }
}
