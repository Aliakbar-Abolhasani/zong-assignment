using System.Collections;
using UnityEngine;

namespace ZongDemo.Gameplay.Objectives
{
    // NOTE: In the actual game, we could make this a serializable POCO instead of MonoBehaviour for more flexibility
    // or we could use behaviorTrees, but since the demo's sequence is not complex, using the MonoBehaviour is easier
    public abstract class ObjectiveAction : MonoBehaviour
    {
        public virtual void OnStart()
        {
        }

        public virtual void OnExit()
        {
        }

        public abstract ActionStatus Execute();
    }
}