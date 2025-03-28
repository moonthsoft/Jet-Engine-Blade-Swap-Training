using System.Collections;
using UnityEngine;

namespace Core.UI
{
    /// <summary>
    /// Class responsible for making fades to black.
    /// It is used, for example, so that the change between scenes is not so abrupt.
    /// </summary>
    public class BlackFade : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _fade;


        public IEnumerator ActiveCoroutine(bool _in)
        {
            _animator.SetBool("active", _in);

            yield return new WaitForSecondsRealtime(_fade.length);
        }
    }
}
