using UnityEngine;

public sealed class DebugTimerAbility : TimerAbilityManager
{
    public override void OnTimerEnd()
    {
        Debug.Log("Adana");
    }

}
