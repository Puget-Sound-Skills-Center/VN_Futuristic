using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class HotelSceneEvent01 : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charKT;
    public GameObject charCoin;
    public GameObject charTobaccio;
    public GameObject textBox;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] AudioSource deskSlam;
    [SerializeField] GameObject ChoiceEventButton1;
    [SerializeField] GameObject ChoiceEventButton2;
    [SerializeField] GameObject ChoiceEventButtonV1;
    [SerializeField] GameObject ChoiceEventButtonV2;
    [SerializeField] GameObject ChoiceEventButtonX1;
    [SerializeField] GameObject ChoiceEventButtonX2;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject charName;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject parkDay;
    [SerializeField] int randomScene;

    void Update()
    {
        textLength = TextCreator.charCount;
    }

    void Start()
    {
        PlayerPrefs.SetInt("LoadState", 5);
        StartCoroutine(EventStarter());
    }


    IEnumerator EventStarter()
    {
        // event 0
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(2);
        charKT.SetActive(true);
        charCoin.SetActive(true);
        // this is where our text function will go in future tutorial
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "What a number.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 1;
    }

    IEnumerator EventOne()
    {
        // event 1
        ChoiceEventButton1.SetActive(false);
        ChoiceEventButton2.SetActive(false);
        charKT.SetActive(true);
        charCoin.SetActive(true);
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "Really? How many got screwed over?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 2;
    }

    IEnumerator EventTwo()
    {
        // event 2
        mainTextObject.SetActive(false);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        charKT.SetActive(true);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "About 6,000 visas declined this morning alone. All from a system error apparently.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 3;
    }

    IEnumerator EventThree()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Refugee #1";
        textToSpeak = "What happened? Did they deny your visa too?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 2;
    }

    IEnumerator EventFour()
    {
        mainTextObject.SetActive(false);
        yield return new WaitForSeconds(1);
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "‘I’d bet a 5. Only because there’s not really a whole lot you can do with a bunch of refugee’s visas and IDs, buying and selling immigrant data is useless, and doesn't hold much value for anything. I’d guess if it was a hack, this was just a slip up at best.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 5;
    }

    IEnumerator EventFive()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "But you gotta admit, this also might affect the job market in the west too, people are desperate for jobs more than ever thanks to those fancy pants relying on mercs more than their own workers.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 6;
    }

    IEnumerator EventSix()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "True. Most refugees coming from the east all have the same reason, the west market wants more workers, and the refugees from the east want sustainability and jobs.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 6;
    }

    IEnumerator EventSeven()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "Then how come this ain’t an easy bet to solve?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 6;
    }

    IEnumerator EventEight()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "It’s the least of their problems, it’s outlaw haven after all.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 6;
    }

    IEnumerator EventNine()
    {
        yield return new WaitForSeconds(1);
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charTobaccio.SetActive(false);
        charCoin.SetActive(true);
        textBox.SetActive(false);
        charName.GetComponent<TMPro.TMP_Text>().text = "";
        textToSpeak = "";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        deskSlam.Play();
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(2);
        nextButton.SetActive(true);
        eventPos = 6;
    }

    public void NextButton()
    {
        if (eventPos == 0)
        {
            StartCoroutine(EventStarter());
        }

        if (eventPos == 1)
        {
            StartCoroutine(EventOne());
        }
        if (eventPos == 2)
        {
            StartCoroutine(EventTwo());
        }
        if (eventPos == 3)
        {
            StartCoroutine(EventThree());
        }
        if (eventPos == 4)
        {
            StartCoroutine(EventFour());
        }
        if (eventPos == 5)
        {
            StartCoroutine(EventFive());
        }

        if (eventPos == 6)
        {
            StartCoroutine(EventSix());
        }

        if (eventPos == 7)
        {
            StartCoroutine(EventSeven());
        }

        if (eventPos == 8)
        {
            StartCoroutine(EventEight());
        }

        if (eventPos == 9)
        {
            StartCoroutine(EventNine());
        }
    }
}
