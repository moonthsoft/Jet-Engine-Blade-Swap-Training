using UnityEngine;

namespace JEBST
{
    public class InteractionCollider : MonoBehaviour
    {
        private enum ColliderType { Tank }

        [SerializeField] private ColliderType _colliderType;

        public void EjecutarLogica()
        {
            // Lógica que debe ejecutarse cuando el raycast golpea el objeto
            Debug.Log("Raycast golpeó el objeto " + gameObject.name);
        }
    }
}