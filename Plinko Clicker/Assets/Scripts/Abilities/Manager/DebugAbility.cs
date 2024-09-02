using UnityEngine;

public sealed class DebugAbility : AbillityManager
{
    public override void OnBuy()
    {
        Debug.Log("Adana");
    }
}
