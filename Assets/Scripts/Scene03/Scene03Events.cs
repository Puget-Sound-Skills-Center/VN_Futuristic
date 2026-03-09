using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene03Events : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charMother;
    public GameObject CharRefugee1;
    public GameObject charRefugee2;
    public GameObject textBox;
    [SerializeField] AudioSource girlSigh;
    [SerializeField] AudioSource girlGasp;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject charName;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject parkDay;
    [SerializeField] GameObject parkNight;
    [SerializeField] GameObject dayBGM;
    [SerializeField] GameObject nightBGM;
    [SerializeField] int randomScene;

    void Update()
    {
        textLength = TextCreator.charCount;
    }

    void Start()
    {
        PlayerPrefs.SetInt("LoadState", 4);
        randomScene = Random.Range(1, 4);
        if (randomScene == 1)
        {
            parkDay.SetActive(true);
            dayBGM.SetActive(true);
        }
        else
        {
            parkNight.SetActive(true);
            nightBGM.SetActive(true);
        }
        StartCoroutine(EventStarter());
    }


    IEnumerator EventStarter()
    {
        // event 0
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(2);
        charMother.SetActive(true);
        // this is where our text function will go in future tutorial
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "...";
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
        nextButton.SetActive(false);
        charMother.SetActive(true);
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

    IEnumerator EventTwo()
    {
        // event 2
        nextButton.SetActive(false);
        charMother.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "Y-yeah… They did. I don't understand why or what's going on?";
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
        charMother.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Refugee #1";
        textToSpeak = "I’m sorry to hear that. I have a husband fighting tooth and nail to get me and my child on the other side but they haven't let me get in contact with him for days.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 4;
    }

    IEnumerator EventFour()
    {
        // event 4
        nextButton.SetActive(false);
        charMother.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Refugee #2";
        textToSpeak = "Same boat too, my daughter was supposed to start school in the west but we couldn’t get in touch without proper visas.";
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
        charMother.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "I… Just don’t understand, why would they deny us and refuse to explain anything? It doesn’t make sense!";
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
        charMother.SetActive(true);
        textBox.SetActive(false);
        yield return new WaitForSeconds(2);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Intercom";
        textToSpeak = "Attention, all refugees; unfortunately the system has been receiving some setbacks at the moment regarding the errors in everyone’s visas declining. At the moment, everyone must stay in their camps or return home until further notice.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 7;
        SceneManager.LoadScene("LimosuineScene01");
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
    }
}
