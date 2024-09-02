using TMPro;
using UnityEngine;

public sealed class BallMoney : AbillityManager
{
    [SerializeField] private TMP_Text description;
    [SerializeField] private float moneyUpgradeAmount = 0.1f;
    public override void OnBuy(){
        BallManager.Instance().ballsMoney += moneyUpgradeAmount;
        ResetBallDescription(); 
    }

    private void ResetBallDescription()
    {
        description.text = "It's increase ball money per click.\nBall money: " + Convertor.FloatToDolar(BallManager.Instance().ballsMoney);
    }
}
