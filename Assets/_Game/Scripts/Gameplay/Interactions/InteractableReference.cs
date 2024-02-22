using UnityEngine;

namespace ZongDemo.Gameplay.Interactions
{
    public class InteractableReference : MonoBehaviour
    {
        [field: SerializeField] public Interactable Interactable { get; private set; }
    }
}