using UnityEngine;
using TMPro;
using JEBST.Definitions.Dialogues;
using System.Collections;
using Zenject;
using Core.Managers;
using Core.Definitions.Sounds;

namespace JEBST
{
    /// <summary>
    /// Class responsible for activating/deactivating the dialog interface, 
    /// and displaying the text character by character.
    /// </summary>
    public class DialoguesUI : MonoBehaviour
    {
        private const float TIME_OFFSET = 0.2f;
        private const float TIME_CHAR = 0.01f;
        private const float TIME_COMA = 0.08f;
        private const int CHARS_PER_SOUND = 5;

        private IInputManager _inputManager;
        private IAudioManager _audioManager;
        private bool _active;
        private int _countCharSound = 0;

        [SerializeField] private PauseUI _pauseUI;
        [SerializeField] private ScriptableTexts _scriptableTexts;
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _transition;
        
        [SerializeField] private TMP_Text _textDialogue;


        [Inject] private void InjectInputManager(IInputManager inputManager) { _inputManager = inputManager; }

        [Inject] private void InjectAudioManager(IAudioManager audioManager) { _audioManager = audioManager; }


        private void OnEnable()
        {
            _inputManager.ClickEvent += OnPlayerClick;
        }

        private void OnDisable()
        {
            _inputManager.ClickEvent -= OnPlayerClick;
        }

        public IEnumerator ActiveDialogueCoroutine(Dialogue dialogue)
        {
            string text = _scriptableTexts.GetTextIngame(dialogue);

            //Debug.Log(text);

            _textDialogue.text = "";

            _animator.SetBool("active", true);

            yield return new WaitForSeconds(_transition.length);

            yield return new WaitForSeconds(TIME_OFFSET);

            //Display text character by character
            yield return StartCoroutine(DisplayTextCoroutine(text));

            _active = true;

            while (_active)
            {
                yield return null;
            }

            _animator.SetBool("active", false);

            yield return new WaitForSeconds(_transition.length);

            yield return new WaitForSeconds(TIME_OFFSET);
        }

        private void OnPlayerClick()
        {
            if (_active)
            {
                _active = false;
            }
        }

        private IEnumerator DisplayTextCoroutine(string text)
        {
            _countCharSound = 0;
            int index = 0;
            string stringStart = "";
            string stringEnd = text;

            while (index < text.Length)
            {
                if (!_pauseUI.IsPaused)
                {
                    //For the rich text
                    while (text[index] == '<')
                    {
                        while (text[index] != '>')
                        {
                            stringStart += text[index];
                            stringEnd = stringEnd.Substring(1);
                            index++;

                            if (index >= text.Length)
                            {
                                Debug.LogError("A rich text entry has been started, but the output tag has not been found.");
                            }
                        }

                        stringStart += text[index];
                        stringEnd = stringEnd.Substring(1);
                        index++;
                    }

                    stringStart += text[index];
                    stringEnd = stringEnd.Substring(1);

                    _textDialogue.text = stringStart;
                    _textDialogue.text += "<alpha=#00>";
                    _textDialogue.text += stringEnd;
                    _textDialogue.text += "</alpha>";

                    CheckCharSound();

                    if (text[index] == ',' || text[index] == '.')
                    {
                        yield return new WaitForSeconds(TIME_COMA);
                    }
                    else
                    {
                        yield return new WaitForSeconds(TIME_CHAR);
                    }

                    index++;
                }
                else
                {
                    yield return null;
                }
            }
        }

        private void CheckCharSound()
        {
            if (_countCharSound == 0)
            {
                _audioManager.PlayFx(Fx.DisplayChar, false, true);
            }

            _countCharSound++;

            if (_countCharSound >= CHARS_PER_SOUND)
            {
                _countCharSound = 0;
            }
        }
    }
}