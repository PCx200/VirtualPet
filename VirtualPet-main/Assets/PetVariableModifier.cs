using UnityEngine;

public class PetVariableModifier : StateMachineBehaviour
{
    [Header("Change rates for this state")]
    public float hungerRate = 0f;
    public float lonelinessRate = 0f;

    private PetVariable hungerVar;
    private PetVariable lonelinessVar;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (hungerVar == null)
            hungerVar = animator.GetComponentInChildren<PetVariable>(true); // assumes child GameObjects hold Hunger, etc.
        if (lonelinessVar == null)
        {
            var variables = animator.GetComponentsInChildren<PetVariable>(true);
            foreach (var v in variables)
            {
                if (v.name == "Hunger") hungerVar = v;
                if (v.name == "Loneliness") lonelinessVar = v;
            }
        }

        if (hungerVar != null)
            hungerVar.ChangePerSecond(hungerRate);
        if (lonelinessVar != null)
            lonelinessVar.ChangePerSecond(lonelinessRate);
    }
}
