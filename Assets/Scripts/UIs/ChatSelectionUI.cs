using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatSelectionUI : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject PlayerInfoPanel;
    public GameObject scrollviewContent;
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (Transform item in scrollviewContent.transform)
        {
            Destroy(item.gameObject);
        }
        ShowAllAccpetedPlayerForChat();
    }
    void Start()
    {
        
    }

    public void OnPlayerChatSelect(CharactersStruct customer) 
    {
      
        gameManager.uiManager.textingPanel.ParentObject.SetActive(true);
        gameManager.uiManager.textingPanel.GetCurrentDate(customer);
    }
    void ShowAllAccpetedPlayerForChat() 
    {
        foreach (var item in gameManager.customersManager.acceptedPlayersList)
        {
            var go = Instantiate(PlayerInfoPanel) as GameObject;
            var playerChat = go.GetComponent<PlayerChatInfo>();
           
            switch (item.personalInfo.profession)
            {
                case ProfessionEnum.Policeman:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionPolice;
                    break;
                case ProfessionEnum.Fireman:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionFireman;
                    break;
                case ProfessionEnum.Builder:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionBuilder;
                    break;
                case ProfessionEnum.Doctor:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionDoctor;
                    break;
                case ProfessionEnum.Chef:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionChef;
                    break;
                case ProfessionEnum.Teacher:
                    playerChat.playerPlaceHolder.sprite = gameManager.professionTeacher;
                    break;
                case ProfessionEnum.none:
                    break;
                default:
                    break;
            }
            playerChat.playername.text = item.personalInfo.name.ToString();
            playerChat.OnClickButton.onClick.AddListener(() => { OnPlayerChatSelect(item.personalInfo); });
            go.transform.parent = scrollviewContent.transform;
            var rectT = go.GetComponent<RectTransform>();
            rectT.localPosition = new Vector3(rectT.localPosition.x, rectT.localPosition.y, 0);
            go.transform.localScale = Vector3.one;
        }
    }
}
