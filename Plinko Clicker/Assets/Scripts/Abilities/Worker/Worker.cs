using TMPro;
using UnityEngine;

public sealed class Worker : TimerAbilityManager
{
    [Header("--------Workers Settings----------")]
    [SerializeField] private string workersName = "Beggar";
    [SerializeField] private float money = 5f;
    [SerializeField] private Transform textSpawnPos;
    [SerializeField] private TMP_Text description;

    
    public override void OnUpgrade(){
        description.text = workersName + ", provides $" + (money * PassiveIncreasesManager.multiplier).ToString() + " every " + maxTime.ToString().Substring(0, 4) + " seconds";
    }

    public override void OnTimerEnd()
    {
        GameManager.Instance().AddMoney(money * PassiveIncreasesManager.multiplier);
        JuiceManager.Instance().TextEffect(Convertor.FloatToDolar(money * PassiveIncreasesManager.multiplier), textSpawnPos.position, Color.green);
    }

}
