using UnityEngine;

namespace JEBST
{
    public class InteractionCollider : MonoBehaviour
    {
        private enum ColliderType { Tank }

        [SerializeField] private ColliderType _colliderType;

        public void EjecutarLogica()
        {
            // L�gica que debe ejecutarse cuando el raycast golpea el objeto
            Debug.Log("Raycast golpe� el objeto " + gameObject.name);
        }
    }
}