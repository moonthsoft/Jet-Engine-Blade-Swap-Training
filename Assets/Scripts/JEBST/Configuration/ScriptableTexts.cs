using JEBST.Definitions.Dialogues;
using UnityEngine;

namespace JEBST
{
    [CreateAssetMenu(fileName = "ScriptableTexts", menuName = "Scriptable Objects/Texts")]
    public class ScriptableTexts : ScriptableObject
    {
        [SerializeField] private string[] _dialogues;

        public string GetTextIngame(Dialogue dialogue)
        {
            int indx = (int)dialogue;

            if (indx < 0 || indx >= _dialogues.Length)
            {
                Debug.LogError("The index " + indx + " of the text is incorrect.");

                return "TEXT NOT FOUND";
            }

            return _dialogues[indx];
        }
    }
}