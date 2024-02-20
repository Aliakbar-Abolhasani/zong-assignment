using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Engine.Attributes;

namespace ZongDemo.Gameplay.Objectives
{
    public class SequencePlayer : MonoBehaviour
    {
        [SerializeReference] [SerializeReferenceDropdown(typeof(IActionBase))]
        private List<IActionBase> _action2;

        [SerializeReference] [SerializeReferenceDropdown(typeof(IActionBase))]
        private IActionBase _action;
    }
}