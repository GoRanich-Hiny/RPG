using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction currentAction;

        public void StartAction(IAction action)
        {
            if (currentAction == action) return;
            if (currentAction != null)
            {
                currentAction.Cancel();
            }
            currentAction = action;
        }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        public void CancelCurrentAction()
        {
            StartAction(null);
        }
    }
}