using TMPro;
using UnityEngine;

public sealed class Gambler : TimerAbilityManager
{
    [Header("-----Gambler Settings-------")]

    [SerializeField] private string gamblersName = "Gambler";
    [SerializeField] private int x = 5;
    [SerializeField] private Color ballColor;
    [SerializeField] private bool isTrickBall = false;
    [SerializeField] private Transform textSpawnPos;
    [SerializeField] private TMP_Text description;

    public override void OnUpgrade()
    {
        description.text = gamblersName + ", spawns " + x.ToString() + "x " + (isTrickBall ? "trick " : "") +"ball every " + maxTime.ToString().Substring(0, 4) + " second";
    }

    public override void OnTimerEnd()
    {
        BallManager.Instance().AddBallInArea(x, ballColor, isTrickBall);
        JuiceManager.Instance().TextEffect( x.ToString() +"x", textSpawnPos.position, ballColor);
    }

}
