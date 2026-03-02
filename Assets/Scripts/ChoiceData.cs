using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Choice Data")]
public class ChoiceData : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string speakerName;
        public GameObject speakerObject;
        [TextArea] public string text;
        public string animatorState; // optional animator state to play before/while line
        public float postDelay = 0.5f; // optional extra wait after line
    }

    [System.Serializable]
    public class ChoiceOption
    {
        public string label;
        public DialogueLine[] lines;
        public int nextEventPos = -1; // set to desired eventPos after this option runs
    }

    public ChoiceOption[] options;
}