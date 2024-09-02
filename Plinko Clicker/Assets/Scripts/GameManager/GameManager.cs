using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    [HideInInspector]public float money = 0f;

    [Header("------UI ELEMENTS-------")]
    [SerializeField] private TMP_Text moneyText;

    public static GameManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<GameManager>();
        return instance;
    }

    private void OnEnable(){
        instance = this;
    }

    public void AddMoney(float value){
        money += value;
        if(value!=0) SoundManager.Instance().PlaySFX(SoundManager.Instance().money);
        RestartUI();
        SaveMoney();
    }

    public void ReduceMoney(float value){
        money -= value;
        SoundManager.Instance().PlaySFX(SoundManager.Instance().buy);
        RestartUI();
        SaveMoney();
    }

    private void SaveMoney() => SaveManager.Instance().SaveMoney(money);

    public void RestartUI()
    {
        moneyText.text = Convertor.FloatToDolar(money);
        RestartAbilitiesUI();
    }

    public void RestartAbilitiesUI()
    {
        var abillities = FindObjectsByType<AbillityManager>(FindObjectsSortMode.None);

        foreach(var ability in abillities){
            ability.IsCostBiggerThanMoney();
        }
    }
}
