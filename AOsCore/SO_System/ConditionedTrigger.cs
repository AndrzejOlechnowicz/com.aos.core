using System.Linq;
using AOsCore.SO_System.Data.Variables;
using UnityEngine;

namespace AOsCore.SO_System
{
    public class ConditionedTrigger : Trigger
    {
        [SerializeField] private BoolVar[] conditions;
        
        [Tooltip("Operator to use, one MUST be chosen, if more than one is TRUE function will use former operator will be used")]
        [SerializeField] private bool isOr, isAnd = true;

        protected override void TriggerEnter(Collider other)
        {
            if (!CheckConditions()) return;
            base.TriggerEnter(other);
        }

        protected override void TriggerExit(Collider other)
        {
            if (!CheckConditions()) return;
            base.TriggerExit(other);
        }

        private bool CheckConditions()
        {
            if (isOr)
            {
                return conditions.Any(x => x);
            }
            if (isAnd)
            {
                return conditions.All(x => x);
            }

            return false;
        }
    }
}
