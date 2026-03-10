using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RooftopSceneEvent01 : MonoBehaviour
{
    public GameObject fadeScreenIn;
    public GameObject charMiski;
    public GameObject charCzarina;
    public GameObject textBox;
    public AudioSource girlSigh;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject charName;
    [SerializeField] GameObject fadeOut;
    [SerializeField] Animator Miski01;
    [SerializeField] Animator Czarina02;

    void Update()
    {
        textLength = TextCreator.charCount;
    }

    void Start()
    {
        StartCoroutine(EventStarter());
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
        // this is where our text function will go in future tutorial
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        yield return StartCoroutine(PlayAnimationAndWait(Miski01, "Bounce"));
        textToSpeak = "Hey, remember that poem I let you borrow last week?";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "You mean that damn scroll you passed me in the bathroom stall? I remember.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        textToSpeak = "Do you even know the title of the poem?";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "Tch! Of course I do. My beautiful life by Mistuo Aida.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        textToSpeak = "Do you remember my favorite line?";
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
        // event 4
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "If tomatoes wanted to be melons, they would look completely ridiculous.";
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
        // event 4
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "";
        textToSpeak = "...";
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
        // event 4
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina & Miski";
        yield return StartCoroutine(PlayAnimationAndWait(Miski01, "Bounce"));
        yield return StartCoroutine(PlayAnimationAndWait(Czarina02, "Bounce"));
        textToSpeak = "AHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA!!";
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
        // event 4
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina & Miski";
        textToSpeak = "IT’S JUST A GREAT LINE AFTER AALLLLLL!! HAHAHAHAHA-";
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
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina & Miski";
        textToSpeak = "....";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "But in all seriousness, we got word from Madam Lauretta that we gotta attend the council as well as the other mercs.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        textToSpeak = "Lemme guess, they want us to just sit there and listen to a bunch of old idiots yell at the clouds?";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "Pretty much, she said if we skip out, she’ll cut our expenses in half.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        yield return StartCoroutine(PlayAnimationAndWait(Miski01, "Bounce"));
        girlSigh.Play();
        textToSpeak = "Fine, but if I have to sit next to that purple asshat again, I’m staining something with blood.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "Whatever you say, girl.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        textToSpeak = "By the way, I want that poem back.";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Czarina";
        textToSpeak = "Fine… But it was still a great line AFTER A-";
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
        charMiski.SetActive(true);
        charCzarina.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Miski";
        textToSpeak = "Give me my poem back";
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
        // event 4
        nextButton.SetActive(false);
        charMiski.SetActive(true);
        textBox.SetActive(true);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("BridgeScene02");
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
    }
}
