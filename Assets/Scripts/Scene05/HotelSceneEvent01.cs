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
    public GameObject charKTWhistle;
    public GameObject charKT2;
    public GameObject charCoin;
    public GameObject charCoinHeadDown;
    public GameObject charCoinMouthOpen;
    public GameObject charCoinSmirk;
    public GameObject charTobaccio;
    public GameObject charTobaccioMouthOpen;
    public GameObject charTobaccio2;
    public GameObject charFrontDesk;
    public GameObject textBox;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] AudioSource deskSlam;
    [SerializeField] AudioSource jazzBGM;
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
    [SerializeField] Animator CharShake01;
    [SerializeField] Animator CharShake02;
    [SerializeField] Animator BdgShake03;
    [SerializeField] Animator CharSlideAway01;
    [SerializeField] Animator CharSlideAway02;
    [SerializeField] Animator CharSlideIn01;
    [SerializeField] Animator CharSlideIn02;
    [SerializeField] Animator TobaccioSlideIn03;
    [SerializeField] int randomScene;

    void Update()
    {
        textLength = TextCreator.charCount;
    }

    void Start()
    {
        PlayerPrefs.SetInt("LoadState", 6);
        StartCoroutine(EventStarter());
        jazzBGM.Play();
    }

    IEnumerator PlayAnimationAndWait(Animator animator, string clipName)
    {
        if (animator == null)
            yield break;

        // Try to find clip length from controller clips
        float clipLength = 0f;
        var controller = animator.runtimeAnimatorController;
        if (controller != null)
        {
            foreach (var clip in controller.animationClips)
            {
                if (clip != null && clip.name == clipName)
                {
                    clipLength = clip.length;
                    break;
                }
            }
        }

        // Play the state (state name must match clipName or be a state with that name)
        animator.Play(clipName, 0, 0f);

        if (clipLength > 0f)
            yield return new WaitForSeconds(clipLength);
        else
        {
            // Fallback: wait one frame to allow Animator to switch, then poll for state entry (timeout to avoid infinite loop)
            yield return null;
            float timeout = 1.5f; // seconds
            float timer = 0f;
            while (timer < timeout)
            {
                var state = animator.GetCurrentAnimatorStateInfo(0);
                if (state.IsName(clipName))
                {
                    // If the state reports a length, use it; otherwise wait a small default
                    float stateLength = state.length;
                    if (stateLength > 0f)
                    {
                        yield return new WaitForSeconds(stateLength);
                    }
                    else
                    {
                        yield return new WaitForSeconds(0.5f);
                    }
                    yield break;
                }
                timer += Time.deltaTime;
                yield return null;
            }
            // If we timed out, just continue
        }
    }

    IEnumerator EventStarter()
    {
        // event 0
        yield return new WaitForSeconds(3);
        fadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(3);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(false);
        charKTWhistle.SetActive(true);
        charKT2.SetActive(false);
        charCoin.SetActive(false);
        charCoinHeadDown.SetActive(true);
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
        nextButton.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKTWhistle.SetActive(false);
        charKT2.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(true);
        charCoinHeadDown.SetActive(false);
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
        nextButton.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(true);
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
        charCoin.SetActive(false);
        charCoinSmirk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "Damn... How much you wanna bet it was a hack by another merc?";
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
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinSmirk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "I’d bet a 5. Only because there’s not really a whole lot you can do with a bunch of refugee’s visas and IDs, buying and selling immigrant data is useless, and doesn't hold much value for anything. I’d guess if it was a hack, this was just a slip up at best.";
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
        charCoin.SetActive(false);
        charCoinSmirk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKT2.SetActive(false);
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
        charCoinSmirk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(true);
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
        eventPos = 7;
    }

    IEnumerator EventSeven()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(true);
        charCoinSmirk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKT2.SetActive(false);
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
        eventPos = 8;
    }

    IEnumerator EventEight()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinSmirk.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(true);
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
        eventPos = 9;
    }

    IEnumerator EventNine()
    {
        yield return new WaitForSeconds(1);
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        deskSlam.Play();
        yield return StartCoroutine(PlayAnimationAndWait(BdgShake03, "BdgShake"));
        yield return StartCoroutine(PlayAnimationAndWait(CharShake01, "CharShake01"));
        yield return StartCoroutine(PlayAnimationAndWait(CharShake02, "CharShake02"));
        charName.GetComponent<TMPro.TMP_Text>().text = "";
        textToSpeak = "!!!";
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
        yield return new WaitForSeconds(1);
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(false);
        charFrontDesk.SetActive(false);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        yield return StartCoroutine(PlayAnimationAndWait(CharSlideAway01, "SlideAway01"));
        yield return StartCoroutine(PlayAnimationAndWait(CharSlideAway02, "SlideAway02"));
        charName.GetComponent<TMPro.TMP_Text>().text = "";
        textToSpeak = "";
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
        yield return new WaitForSeconds(1);
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        yield return StartCoroutine(PlayAnimationAndWait(CharSlideIn01, "SlideIn01"));
        charName.GetComponent<TMPro.TMP_Text>().text = "";
        textToSpeak = "";
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
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        textToSpeak = "YOU'RE CHARGING HOW MUCH FOR A ROOM?!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 13;
    }

    IEnumerator EventThirteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Front Desk Lady";
        textToSpeak = "F-for a luxury suite, i-it’s $500 per night, sir…";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 14;
    }
    IEnumerator EventFourteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        yield return StartCoroutine(PlayAnimationAndWait(BdgShake03, "BdgShake"));
        textToSpeak = "Che Idiozia! What the hell could you possibly offer to justify that price?!";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 15;
    }

    IEnumerator EventFifteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Front Desk Lady";
        textToSpeak = "W-we offer… um… a king-sized bed, luxury bedding, a spa bathroom with bath essentials, in-room dining, a mini-bar and-";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 16;
    }

    IEnumerator EventSixteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        textToSpeak = "Wait wait wait wait… You said a mini-bar?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 17;
    }

    IEnumerator EventSeventeen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Front Desk Lady";
        textToSpeak = "Y-yes sir. We offer a m-mini-bar… f-fully stocked, with premium s-spirits, wines, and champagne.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 18;
    }

    IEnumerator EventEighteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        textToSpeak = "...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 19;
    }

    IEnumerator EventNineteen()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(true);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(true);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        textToSpeak = "You. Woman. Go steal money for me.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 20;
    }

    IEnumerator EventTwenty()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(false);
        charTobaccio2.SetActive(false);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "I'll pass, thanks";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 21;
    }

    IEnumerator EventtwentyOne()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccioMouthOpen.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        yield return StartCoroutine(PlayAnimationAndWait(TobaccioSlideIn03, "SlideInTobaccio"));
        textToSpeak = "Then what’re you idiots yappin’ over there?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 22;
    }

    IEnumerator EventTwentyTwo()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(true);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "Just talking about the numbers of visa rejections.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 23;
    }

    IEnumerator EventTwentyThree()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "And these numbers don’t plan on slowing down anytime soon. People are desperate to make money.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 24;
    }

    IEnumerator EventTwentyFour()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(true);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "Yeah, and that spells good business for mercs.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 25;
    }

    IEnumerator EventTwentyFive()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "I guess, but I’d rather not have to deal with idiots trying to kill us every now and then.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 26;
    }

    IEnumerator EventTwentySix()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(true);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "You think we should check out the council?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 27;
    }

    IEnumerator EventTwentySeven()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio";
        textToSpeak = "And hear them talk about what? Shit that has nothing to do with anything?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 28;
    }

    IEnumerator EventTwentyEight()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "K.T";
        textToSpeak = "Well, I do know one place where we can watch the meeting without being seen.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 29;
    }

    IEnumerator EventTwentyNine()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(false);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(true);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(true);
        charKT2.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Coin";
        textToSpeak = "And besides,  I think that’s a gamble worth taking, wanna bet on it?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 30;
    }

    IEnumerator EventThirty()
    {
        nextButton.SetActive(false);
        charCoin.SetActive(true);
        charCoinMouthOpen.SetActive(false);
        charCoinSmirk.SetActive(false);
        charFrontDesk.SetActive(false);
        charTobaccio.SetActive(false);
        charTobaccio2.SetActive(true);
        charKT.SetActive(false);
        charKT2.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Tobaccio & K.T";
        textToSpeak = "No.";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        nextButton.SetActive(true);
        eventPos = 31;
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(7);
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

        if (eventPos == 13)
        {
            StartCoroutine(EventThirteen());
        }

        if (eventPos == 14)
        {
            StartCoroutine(EventFourteen());
        }

        if (eventPos == 15)
        {
            StartCoroutine(EventFifteen());
        }

        if (eventPos == 16)
        {
            StartCoroutine(EventSixteen());
        }

        if (eventPos == 17)
        {
            StartCoroutine(EventSeventeen());
        }

        if (eventPos == 18)
        {
            StartCoroutine(EventEighteen());
        }

        if (eventPos == 19)
        {
            StartCoroutine(EventNineteen());
        }

        if (eventPos == 20)
        {
            StartCoroutine(EventTwenty());
        }

        if (eventPos == 21)
        {
            StartCoroutine(EventtwentyOne());
        }

        if (eventPos == 22)
        {
            StartCoroutine(EventTwentyTwo());
        }

        if (eventPos == 23)
        {
            StartCoroutine(EventTwentyThree());
        }

        if (eventPos == 24)
        {
            StartCoroutine(EventTwentyFour());
        }

        if (eventPos == 25)
        {
            StartCoroutine(EventTwentyFive());
        }

        if (eventPos == 26)
        {
            StartCoroutine(EventTwentySix());
        }

        if (eventPos == 27)
        {
            StartCoroutine(EventTwentySeven());
        }

        if (eventPos == 28)
        {
            StartCoroutine(EventTwentyEight());
        }

        if (eventPos == 29)
        {
            StartCoroutine(EventTwentyNine());
        }

        if (eventPos == 30)
        {
            StartCoroutine(EventThirty());
        }
    }
}