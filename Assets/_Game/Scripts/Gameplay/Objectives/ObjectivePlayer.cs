using System;
using System.Collections;
using UnityEngine;

namespace ZongDemo.Gameplay.Objectives
{
    public class ObjectivePlayer : MonoBehaviour
    {
        [SerializeField] private ObjectiveAction _action;

        private void Start()
        {
            StartCoroutine(PlayAction(_action));
        }

        private static IEnumerator PlayAction(ObjectiveAction action)
        {
            action.OnStart();

            while (true)
            {
                var status = action.Execute();
                if (status == ActionStatus.Running)
                {
                    yield return null;
                }
                else
                {
                    break;
                }
            }

            action.OnExit();
        }
    }
}