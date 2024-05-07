using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hellmade.Sound;

public class TextingPanel : MonoBehaviour
{
    public GameObject ParentObject;
    public GameManager gameManager;
    public Image placeHolderForPlayer;
    public Text namePlayer;
    public Text optionsA, optionsB;
    public GameObject scrollviewContent;
    public ScrollRect scrollView;
    // Start is called before the first frame update
    public GameObject whiteBubblePrefab, RedBubble, GreenBuble;
    private GameObject ChatingBubble;
    private CharactersStruct currentTextingData;
    private int currentTexting = 0;
    public AudioClip chatsound;
    public List<QuestionStruct> correctQuestion;
    public List<QuestionStruct> wrongQuestions;
    private int correctAnwerFirst = 0;
    private bool isMessage = false;
    private void OnEnable()
    {
        foreach (Transform item in scrollviewContent.transform)
        {
            Destroy(item.gameObject);
        }
    }
    public void ClickOnOption(int opt)
    {
        if (!isMessage)
        {
            return;
        }
        EazySoundManager.PlaySound(chatsound);
        if (ChatingBubble != null)
        {
            ChatingBubble.GetComponent<BubbleAnswer>().StopRoutine();
            if (opt == correctAnwerFirst)
            {
                ChatingBubble.GetComponent<BubbleAnswer>().text.text = correctQuestion[currentTexting].Question;
            }
            else
            {
                ChatingBubble.GetComponent<BubbleAnswer>().text.text = wrongQuestions[currentTexting].Question;
            }
        }
        if (opt == correctAnwerFirst)
        {
            //correct
            StartCoroutine(ShowReply(true));
        }
        else
        {
            //wrong
            StartCoroutine(ShowReply(false));
        }
    }
    public void ShowChattingBubble()
    {
        ChatingBubble = Instantiate(whiteBubblePrefab) as GameObject;
        ChatingBubble.transform.SetParent(scrollviewContent.transform);
        var rectT = ChatingBubble.GetComponent<RectTransform>();
        rectT.localPosition = new Vector3(rectT.localPosition.x, rectT.localPosition.y, 0);
        ChatingBubble.transform.localScale = Vector3.one;
        StartCoroutine(PushToBottom());

    }
    IEnumerator ShowReply(bool Correct) 
    {
        isMessage = false;
        yield return new WaitForEndOfFrame();
      
        if (Correct)
        {
            var go = Instantiate(GreenBuble) as GameObject;
            go.transform.SetParent(scrollviewContent.transform);
            var rectT = go.GetComponent<RectTransform>();
            rectT.localPosition = new Vector3(rectT.localPosition.x, rectT.localPosition.y, 0);
            go.transform.localScale = Vector3.one;
            StartCoroutine(PushToBottom());

            yield return new WaitForSeconds(2);
            EazySoundManager.PlaySound(chatsound);
            go.GetComponent<BubbleAnswer>().StopRoutine();
            go.GetComponent<BubbleAnswer>().text.text = correctQuestion[currentTexting].Replay;
            gameManager.correctStatmentAnswers++;
        }
        else
        {
            var go = Instantiate(RedBubble) as GameObject;
            go.transform.SetParent(scrollviewContent.transform);
            var rectT = go.GetComponent<RectTransform>();
            rectT.localPosition = new Vector3(rectT.localPosition.x, rectT.localPosition.y, 0);
            go.transform.localScale = Vector3.one;
            StartCoroutine(PushToBottom());
            yield return new WaitForSeconds(2);
            EazySoundManager.PlaySound(chatsound);
            go.GetComponent<BubbleAnswer>().StopRoutine();
            go.GetComponent<BubbleAnswer>().text.text = wrongQuestions[currentTexting].Replay;
        }
        yield return new WaitForSeconds(0.2f);
       
        AskNextOption();
    }
    public void ShowOptions(string a, string b, int correctLeft) 
    {
        optionsA.text = a;
        optionsB.text = b;
        correctAnwerFirst = correctLeft;
    }
    public void AskNextOption() 
    {
        currentTexting++;

        if (currentTexting < correctQuestion.Count)
        {
            isMessage = true;
            var ran = Random.Range(0, 50);
            if (ran % 2 == 0)
            {
                ShowChattingBubble();
                ShowOptions(correctQuestion[currentTexting].Question, wrongQuestions[currentTexting].Question, 1);
            }
            else
            {
                ShowChattingBubble();
                ShowOptions(wrongQuestions[currentTexting].Question, correctQuestion[currentTexting].Question, 2);
            }
        }
        else
        {
            StartCoroutine(wait());
        }

    }
    IEnumerator wait() 
    {
        yield return new WaitForSeconds(1);
        gameManager.uiManager.DisableAllScreens();
        gameManager.uiManager.ShowScreen(UIManager.UIScreens.ChatResultsUI);
    }
    public void GetCurrentDate(CharactersStruct texting) 
    {
        namePlayer.text = texting.name.ToString();
      //  placeHolderForPlayer.sprite = texting.personalInfo.playerPotrait;
        currentTextingData = texting;
        currentTexting = 0;
        correctQuestion = gameManager.questionsData.GetRandomCorrectQuestions(5);
        wrongQuestions = gameManager.questionsData.GetRandomWrongQuestions(5);
        gameManager.totalQustions = correctQuestion.Count;
        if (correctQuestion.Count >=1)
        {
            StartCoroutine(wait1());
           // currentTexting ++;
        }
    }
    IEnumerator wait1() 
    {
        yield return new WaitForSeconds(0.3f);
        ShowOptions(correctQuestion[currentTexting].Question, wrongQuestions[currentTexting].Question, 1);
        ShowChattingBubble();
        isMessage = true;
    }
    IEnumerator PushToBottom()
    {
        yield return new WaitForEndOfFrame();
        scrollView.verticalNormalizedPosition = 0;
        LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)scrollView.transform);
    }
}
