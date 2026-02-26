using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene02Event : MonoBehaviour
{
    public GameObject textBox;
    [SerializeField] GameObject fadeScreenIn;
    [SerializeField] GameObject MigrationOfficer;
    [SerializeField] GameObject Mother;
    [SerializeField] GameObject MotherAgitated;
    [SerializeField] GameObject MotherDesperate;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    //[SerializeField] GameObject treeInteract;
    //[SerializeField] GameObject houseInteract;
    [SerializeField] GameObject charAkane;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject charName;
    //these are for the randomized scene
    [SerializeField] GameObject parkDay;
    [SerializeField] GameObject parkNight;
    [SerializeField] GameObject dayBGM;
    [SerializeField] GameObject nightBGM;
    [SerializeField] int randomScene;

    // Animator for Mother bounce animation (assign in Inspector or it will be auto-found)
    [SerializeField] Animator motherAnimator;

    void Awake()
    {
        // Auto-find animator on Mother if not assigned in inspector
        if (motherAnimator == null && Mother != null)
            motherAnimator = Mother.GetComponent<Animator>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("LoadState", 2);
        randomScene = Random.Range(1, 3);
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



    void Update()
    {
        textLength = TextCreator.charCount;
    }

    IEnumerator EventStarter()
    {
        // event 0
        yield return new WaitForSeconds(2);
        fadeScreenIn.SetActive(true);
        yield return new WaitForSeconds(2);
        // this is where our text function will go in future tutorial
        mainTextObject.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "Sorry miss, but your visa has been declined.";
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
        //event 1
        nextButton.SetActive(false);
        Mother.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "W-what?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        // Play bounce animation on Mother (Animator must have a clip/state named "Bounce")
        if (motherAnimator == null && Mother != null)
            motherAnimator = Mother.GetComponent<Animator>();

        if (motherAnimator != null)
        {
            // Trigger a bounce (if you use a trigger parameter instead of a direct state name,
            // replace SetTrigger with the parameter name you configured)
            // Example: motherAnimator.SetTrigger("BounceTrigger");
            // The coroutine below will try to play the state named "Bounce" and wait for its length.
            yield return StartCoroutine(PlayAnimationAndWait(motherAnimator, "Bounce"));
        }
        else
        {
            Debug.LogWarning("motherAnimator not assigned and no Animator found on Mother. Bounce animation skipped.");
        }
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);

        nextButton.SetActive(true);
        eventPos = 2;
    }

    /// <summary>
    /// Plays an Animator state/clip by name and waits for the clip length if the clip is found in the controller.
    /// The Animator must contain a state/clip with exactly the same name as clipName.
    /// </summary>
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

    IEnumerator EventTwo()
    {
        //event 2
        nextButton.SetActive(false);
        Mother.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "Your access to the west district is denied, you’ll have to return home for now.";
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
        //event 3
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "But… How?! My visa doesn’t have any problems! How is this possible?!";
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
        //event 4
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "Unfortunately, there’s been an error in the system which temporarily nullified your visa privileges, you will have to return home until the situation is handled.";
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
        //event 5
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "This… Can’t be happening…  I-I have to cross! My child needs medication!";
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
        //event 6
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "Sorry, miss, but protocol says no one can cross districts until the situation is resolved.";
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
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "Please! I need to cross! My husband is waiting for me on the other side! My family is waiting for me!";
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
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "Like I said, miss, you’ll have to return home until the situation is resolved like everyone else, there’s simply nothing else I can do for you.";
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
        MigrationOfficer.SetActive(true);
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        textBox.SetActive(true);
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
        eventPos = 10;
    }

    IEnumerator EventTen()
    {
        nextButton.SetActive(false);
        Mother.SetActive(true);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(false);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        // Play WalkAway animation on Mother (Animator must have a clip/state named "WalkAway")
        if (motherAnimator == null && Mother != null)
            motherAnimator = Mother.GetComponent<Animator>();

        if (motherAnimator != null)
        {
            // Trigger a WalkAway (if you use a trigger parameter instead of a direct state name,
            // replace SetTrigger with the parameter name you configured)
            // Example: motherAnimator.SetTrigger("WalkAwayTrigger");
            // The coroutine below will try to play the state named "WalkAway" and wait for its length.
            yield return StartCoroutine(PlayAnimationAndWait(motherAnimator, "WalkAway"));
        }
        else
        {
            Debug.LogWarning("motherAnimator not assigned and no Animator found on Mother. WalkAway animation skipped.");
        }
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
    }
}
