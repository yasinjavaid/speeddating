using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private string animTriggerLab;
    [SerializeField] private string animTriggerReception;
    [SerializeField] private string animTriggerVaccination;
    [SerializeField] private string animTriggerDance;
    [SerializeField] private string animTriggerDie;
    [SerializeField] private GameObject confettiParticle;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void CameraGoToLabAnim() 
    {
        anim?.SetTrigger(animTriggerLab);
    }
    public void CameraGoToVaccinationAnim()
    {
        anim?.SetTrigger(animTriggerVaccination);
    }
    public void CameraGoToReception() 
    {
        anim?.SetTrigger(animTriggerReception);
    }
    public void CameraGoToDanceAnim()
    {
        anim?.SetTrigger(animTriggerDance);
    }
    public void CameraGoToDieAnim()
    {
        anim?.SetTrigger(animTriggerDie);
    }
    public void SetParticle(bool act) 
    {
        confettiParticle.SetActive(act);
    }
}
