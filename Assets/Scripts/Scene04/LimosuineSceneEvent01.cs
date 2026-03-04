using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LimosuineSceneEvent01 : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charDarlin;
    public GameObject CharThomasValentine;
    public GameObject textBox;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
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
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        // this is where our text function will go in future tutorial
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'arlin";
        textToSpeak = "Y’know, that holier-than-thou look is getting old. You look like you crawled out of the 1500s, you should let me give you a makeover sometime.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        //nextButton.SetActive(true);
        yield return new WaitForSeconds(2);
        mainTextObject.SetActive(false);
        ChoiceEventButton1.SetActive(true);
        ChoiceEventButton2.SetActive(true);
        ChoiceEventButton1.GetComponentInChildren<TMPro.TMP_Text>().text = "Insult";
        ChoiceEventButton2.GetComponentInChildren<TMPro.TMP_Text>().text = "Ignore";
        eventPos = 1;
    }

    public void ChoiceEvent1()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButton1.SetActive(false);
        ChoiceEventButton2.SetActive(false);
        StartCoroutine(ChoiceSeq1());
    }
    public void ChoiceEvent2()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButton1.SetActive(false);
        ChoiceEventButton2.SetActive(false);
        StartCoroutine(ChoiceSeq2());
    }

    IEnumerator ChoiceSeq1()
    {
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "Appearance doesn’t dictate actions or words, but of course it’d be too much of asking you of all people to understand that statement.";
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

    IEnumerator ChoiceSeq2()
    {
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 12;
    }

    IEnumerator EventTwelve()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "Or not... Typical you.";
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

    IEnumerator EventOne()
    {
        // event 1
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "Appearance doesn’t dictate actions or words, but of course it’d be too much of asking you of all people to understand that statement.";
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
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "Just a suggestion.";
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
        // event 3
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "But… I did hear how the migration system’s been getting out of hand recently, how do you think the council is gonna tackle that?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        //nextButton.SetActive(true);
        yield return new WaitForSeconds(2);
        mainTextObject.SetActive(false);
        ChoiceEventButtonV1.SetActive(true);
        ChoiceEventButtonV2.SetActive(true);
        ChoiceEventButtonV1.GetComponentInChildren<TMPro.TMP_Text>().text = "Truth";
        ChoiceEventButtonV2.GetComponentInChildren<TMPro.TMP_Text>().text = "Dismiss";
        eventPos = 4;
    }

    public void ChoiceEventV1()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButtonV1.SetActive(false);
        ChoiceEventButton2.SetActive(false);
        StartCoroutine(ChoiceSeqV1());
    }
    public void ChoiceEventV2()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButtonV1.SetActive(false);
        ChoiceEventButtonV2.SetActive(false);
        StartCoroutine(ChoiceSeqV2());
    }

    IEnumerator ChoiceSeqV1()
    {
        nextButton.SetActive(false);
        CharThomasValentine.SetActive(true);
        charDarlin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "They will have to resolve it whether they like it or not. When nothing affects nobles, nothing concerns them. That’s simply the human mindset.";
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

    IEnumerator ChoiceSeqV2()
    {
        nextButton.SetActive(false);
        CharThomasValentine.SetActive(true);
        charDarlin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "We will discover that for ourselves when we get there. The council is known for leaving concerns that are... 'Out of their control'... to be silent. And as you can tell, nobles from the west district have already grown numb to the lack of communication.";
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

    IEnumerator EventFour()
    {
        // event 4
        nextButton.SetActive(false);
        CharThomasValentine.SetActive(true);
        charDarlin.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "They will have to resolve it whether they like it or not. When nothing affects nobles, nothing concerns them. That’s simply the human mindset.";
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
        // event 5
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "Spoken like a true noble.";
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
        // event 6
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "This IS my limosuine, y'know...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 7;
    }

    IEnumerator EventSeven()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "Just sayin'...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 8;
    }

    IEnumerator EventEight()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "But, that doesn’t answer the question. Council meetings like this continental never happen ever, the rumors are that the matters consist of mercenaries and the plummeting economy of both districts.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        //nextButton.SetActive(true);
        yield return new WaitForSeconds(2);
        mainTextObject.SetActive(false);
        ChoiceEventButtonX1.SetActive(true);
        ChoiceEventButtonX2.SetActive(true);
        ChoiceEventButtonX1.GetComponentInChildren<TMPro.TMP_Text>().text = "Truth";
        ChoiceEventButtonX2.GetComponentInChildren<TMPro.TMP_Text>().text = "Realistic";
        eventPos = 9;
    }

    public void ChoiceEventX1()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButtonX1.SetActive(false);
        ChoiceEventButtonX2.SetActive(false);
        StartCoroutine(ChoiceSeqX1());
    }
    public void ChoiceEventX2()
    {
        // disable choices immediately to prevent double clicks and start sequence
        ChoiceEventButtonX1.SetActive(false);
        ChoiceEventButtonX2.SetActive(false);
        StartCoroutine(ChoiceSeqX2());
    }

    IEnumerator ChoiceSeqX1()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "The Migration system has been a recurring issue for several months, I wouldn’t put it past them to try and brush it aside, but that is an issue I won’t allow to be silent.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 10;
    }

    IEnumerator ChoiceSeqX2()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "To be quite frank, they'll most likely gaslight the matter into spinning it as justifiable progression, possibly to soften the reputation of themselves and close ties, more specifically MPC.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 10;
    }

    IEnumerator EventNine()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "The Migration system has been a recurring issue for several months, I wouldn’t put it past them to try and brush it aside, but that is an issue I won’t allow to be silent.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 10;
    }

    IEnumerator EventTen()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "D'Arlin";
        textToSpeak = "Yeah yeah, just try not to expose every single person there and their secrets. And just to be clear, my business practices are authentic and man made.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 11;
    }

    IEnumerator EventEleven()
    {
        nextButton.SetActive(false);
        charDarlin.SetActive(true);
        CharThomasValentine.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Thomas Valentine";
        textToSpeak = "I don't care about your business.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 11;
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

        if (eventPos == 10)
        {
            StartCoroutine(EventTen());
        }

        if (eventPos == 11)
        {
            StartCoroutine(EventEleven());
        }

        if (eventPos == 12)
        {
            StartCoroutine(EventTwelve());
        }
    }
}
