using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene02Event : MonoBehaviour
{
    public GameObject textBox;
    [SerializeField] GameObject fadeScreenIn;
    [SerializeField] GameObject MigrationOfficer;
    [SerializeField] GameObject MigrationOfficerHeadTilt;
    [SerializeField] GameObject MigrationOfficerFinger;
    [SerializeField] GameObject MigrationOfficerHandWave;
    [SerializeField] GameObject Mother;
    [SerializeField] GameObject MotherStunned;
    [SerializeField] GameObject MotherAgitated;
    [SerializeField] GameObject MotherDesperate;
    [SerializeField] GameObject MotherCry;
    [SerializeField] GameObject MotherCryWalkAway;
    [SerializeField] string textToSpeak;
    [SerializeField] int currentTextLength;
    [SerializeField] int textLength;
    [SerializeField] GameObject mainTextObject;
    [SerializeField] GameObject nextButton;
    [SerializeField] int eventPos = 0;
    [SerializeField] GameObject Choice1;
    [SerializeField] GameObject Choice2;
    [SerializeField] GameObject ChoiceV1;
    [SerializeField] GameObject ChoiceV2;
    [SerializeField] GameObject charAkane;
    [SerializeField] GameObject fadeOut;
    [SerializeField] GameObject charName;
    //these are for the randomized scene
    [SerializeField] GameObject parkDay;
    [SerializeField] GameObject parkNight;
    [SerializeField] int randomScene;

    // Animator for Mother bounce/walk animations (assign in Inspector or it will be auto-found)
    [SerializeField] Animator motherAnimator;
    [SerializeField] Animator MotherWalkAway;
    [SerializeField] Animator StunBounce;

    void Awake()
    {
        // Auto-find animator on Mother if not assigned in inspector
        if (motherAnimator == null && Mother != null)
            motherAnimator = Mother.GetComponent<Animator>();

        if (MotherWalkAway == null && MotherCryWalkAway != null)
            MotherWalkAway = Mother.GetComponent<Animator>();

        if (StunBounce == null && MotherStunned != null)
            StunBounce = Mother.GetComponent<Animator>();
    }

    void Start()
    {
        PlayerPrefs.SetInt("LoadState", 2);
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
        Mother.SetActive(false);
        MotherStunned.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "W-what?";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return StartCoroutine(PlayAnimationAndWait(StunBounce, "Bounce"));
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
        Mother.SetActive(false);
        MotherStunned.SetActive(true);
        MigrationOfficer.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(true);
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
        nextButton.SetActive(false);
        eventPos = 3;
        // Prepare and show simple two-option choices (legacy coroutine-based handling)
        nextButton.SetActive(true);
        eventPos = 2_5;
        //Prepare and show simple two-option choices (legacy coroutine-based handling)
        yield return new WaitForSeconds(2);
        mainTextObject.SetActive(true);
        Choice1.SetActive(true);
        Choice2.SetActive(true);
        Choice1.GetComponentInChildren<TMPro.TMP_Text>().text = "Agitated";
        Choice2.GetComponentInChildren<TMPro.TMP_Text>().text = "Polite";

        // Return and let the choice button callbacks start the appropriate IEnumerator (Choice1Seq / Choice2Seq).
        // Do NOT block here; choice coroutines will set eventPos when finished.
    }

    // These methods are intended to be assigned to the UI Buttons for the choices.
    // They now start the coroutine sequences directly (IEnumerator-based flow).
    public void Choice1Event()
    {
        // disable choices immediately to prevent double clicks and start sequence
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        StartCoroutine(Choice1Seq());
    }

    public void Choice2Event()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
        StartCoroutine(Choice2Seq());
    }

    IEnumerator Choice1Seq()
    {
        // Outcome for choice 1 (legacy; coroutine-driven)
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherStunned.SetActive(false);
        MotherCry.SetActive(false);
        MotherDesperate.SetActive(false);
        MotherAgitated.SetActive(true);
        MigrationOfficer.SetActive(true);
        MigrationOfficerHeadTilt.SetActive(false);
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

    IEnumerator Choice2Seq()
    {
        // Outcome for choice 2 (legacy; coroutine-driven)
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        Mother.SetActive(true);
        MotherAgitated.SetActive(false);
        MotherStunned.SetActive(false);
        MigrationOfficer.SetActive(true);
        MigrationOfficerHeadTilt.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "Oh. Well... Can I ask why that is?";
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

    IEnumerator EventThree()
    {
        //event 3
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(true);
        MotherStunned.SetActive(false);
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
        mainTextObject.SetActive(true);
        Mother.SetActive(true);
        MotherStunned.SetActive(false);
        MotherAgitated.SetActive(false);
        MigrationOfficer.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(true);
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
        MotherStunned.SetActive(false);
        MigrationOfficer.SetActive(true);
        MigrationOfficerHeadTilt.SetActive(false);
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
        MotherStunned.SetActive(false);
        MigrationOfficer.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(true);
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

        // Prepare and show simple two-option choices (legacy coroutine-based handling)
        yield return new WaitForSeconds(2);
        //nextButton.SetActive(true);
        mainTextObject.SetActive(true);
        ChoiceV1.SetActive(true);
        ChoiceV2.SetActive(true);
        ChoiceV1.GetComponentInChildren<TMPro.TMP_Text>().text = "Plead";
        ChoiceV2.GetComponentInChildren<TMPro.TMP_Text>().text = "Lash out";
        // Return and let the choice button callbacks start the appropriate IEnumerator (Choice1Seq / Choice2Seq).
    }

    public void ChoiceEvent1Button()
    {
        ChoiceV1.SetActive(false);
        ChoiceV2.SetActive(false);
        StartCoroutine(ChoiceEvent1());
    }

    public void ChoiceEvent2Button()
    {
        ChoiceV1.SetActive(false);
        ChoiceV2.SetActive(false);
        StartCoroutine(ChoiceEvent2());
    }

    IEnumerator ChoiceEvent1()
    {
        // Outcome for choice 1 (legacy; coroutine-driven)
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherCry.SetActive(false);
        MotherStunned.SetActive(false);
        MotherDesperate.SetActive(true);
        MotherAgitated.SetActive(false);
        MigrationOfficer.SetActive(true);
        MigrationOfficerHeadTilt.SetActive(false);
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

    IEnumerator ChoiceEvent2()
    {
        mainTextObject.SetActive(true);
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherStunned.SetActive(false);
        MotherCry.SetActive(false);
        MotherDesperate.SetActive(false);
        MotherAgitated.SetActive(true);
        MigrationOfficer.SetActive(true);
        MigrationOfficerHeadTilt.SetActive(false);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "Are you serious?! All you can tell us is go home and not elaborate?! My home was destroyed! Did you even try?!";
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
        Mother.SetActive(false);
        MotherAgitated.SetActive(true);
        MotherDesperate.SetActive(false);
        MigrationOfficer.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(false);
        MigrationOfficerFinger.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Migration Officer";
        textToSpeak = "I understand your frustration, miss, but for everyone's safety, no refugees are permitted to enter or leave the district until further notice. Standard protocol.";
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

    IEnumerator EventSeven()
    {
        nextButton.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(true);
        MotherStunned.SetActive(false);
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
        MigrationOfficer.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(false);
        MigrationOfficerHandWave.SetActive(true);
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
        MigrationOfficerHandWave.SetActive(false);
        MigrationOfficerFinger.SetActive(false);
        MigrationOfficerHeadTilt.SetActive(false);
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(false);
        MotherStunned.SetActive(false);
        MotherCry.SetActive(true);
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
        Mother.SetActive(false);
        MotherAgitated.SetActive(false);
        MotherDesperate.SetActive(false);
        MotherCry.SetActive(false);
        MotherStunned.SetActive(false);
        MotherCryWalkAway.SetActive(true);
        MigrationOfficer.SetActive(true);
        textBox.SetActive(true);
        charName.GetComponent<TMPro.TMP_Text>().text = "Mother";
        textToSpeak = "...";
        textBox.GetComponent<TMPro.TMP_Text>().text = textToSpeak;
        currentTextLength = textToSpeak.Length;
        TextCreator.runTextPrint = true;
        yield return StartCoroutine(PlayAnimationAndWait(MotherWalkAway, "WalkAway"));
        yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => textLength == currentTextLength);
        yield return new WaitForSeconds(0.5f);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        eventPos = 9;
        SceneManager.LoadScene("BridgeScene03");
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
    }
}