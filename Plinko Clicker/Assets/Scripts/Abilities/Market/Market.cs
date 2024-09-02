using TMPro;
using UnityEngine;

public sealed class Market : AbillityManager
{
    [SerializeField] private TMP_Text description;

    public override void OnBuy()
    {
        PassiveIncreasesManager.multiplier++;
        ResetDescription();
    }

    private void Start() => Invoke(nameof(ResetDescription), .1f);

    private void ResetDescription(){
        description.text = "Market, increases all workers multiplier\nWorkers multiplier:" + PassiveIncreasesManager.multiplier.ToString();
    }
}
