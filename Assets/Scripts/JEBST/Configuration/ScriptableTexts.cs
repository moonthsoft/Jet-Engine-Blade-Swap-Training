using JEBST.Definitions.Dialogues;
using UnityEngine;

namespace JEBST
{
    /// <summary>
    /// Scriptable that contains the texts of the dialogues that will be displayed in the UI to the player.
    /// </summary>
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