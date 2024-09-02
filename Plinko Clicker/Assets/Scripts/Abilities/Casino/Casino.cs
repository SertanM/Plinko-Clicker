using TMPro;
using UnityEngine;

public sealed class Casino : AbillityManager
{
    [SerializeField] private TMP_Text description;
    public override void OnBuy()
    {
        BallManager.Instance().ballsX++;
        ResetDescription();
    }

    private void Start() => Invoke(nameof(ResetDescription), .1f);
    private void ResetDescription() => description.text = "Casino, increase all balls multiplier.\nBalls multiplier:" + BallManager.Instance().ballsX.ToString();
    
}
