using System.Collections;
using UnityEngine;

namespace JEBST
{
    public abstract class MenuUI : MonoBehaviour
    {
        private const float TIME_COOLDOWN = 0.2f;

        private bool _cooldownActive = false;


        protected bool CheckCooldown()
        {
            if (!_cooldownActive)
            {
                StartCoroutine(CooldwonCoroutine());

                return true;
            }
            else
            {
                return false;
            }
        }

        private IEnumerator CooldwonCoroutine()
        {
            _cooldownActive = true;

            yield return new WaitForSeconds(TIME_COOLDOWN);

            _cooldownActive = false;
        }
    }
}