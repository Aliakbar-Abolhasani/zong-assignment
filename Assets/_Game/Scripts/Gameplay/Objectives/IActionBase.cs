using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZongDemo.Engine.Attributes;

namespace ZongDemo.Gameplay.Objectives
{
    // [Serializable]
    public interface IActionBase
    {
        public IEnumerator Execute();
    }

    public class Action1 : IActionBase
    {
        [SerializeField] private int f1;
        [SerializeField] private SequencePlayer _player;

        public IEnumerator Execute()
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class Action2 : IActionBase
    {
        [SerializeField] private int f2;
        [SerializeReference] [SerializeReferenceDropdown(typeof(IActionBase))]
        private List<IActionBase> _action2;

        public IEnumerator Execute()
        {
            throw new NotImplementedException();
        }
    }
}