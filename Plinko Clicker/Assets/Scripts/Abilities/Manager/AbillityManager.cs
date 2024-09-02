using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbillityManager : MonoBehaviour 
{
    [SerializeField] private int id;
    [Header("-----------Start Cost-----------")]
    [SerializeField] private float cost = 0.2f;
    [SerializeField] private float costMultiplier = 2f;
    private int level = 0;


    [Header("-----------UI-----------")]
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Button buyButton;

    private void OnEnable(){
        costText.text = Convertor.FloatToDolar(cost);
        GameManager.Instance().RestartAbilitiesUI();
    }

    public void Buy(bool isLoad = false){
        if(cost < GameManager.Instance().money || isLoad){
            OnBuy();
            if(!isLoad) GameManager.Instance().ReduceMoney(cost);
            level++;
            cost *= costMultiplier;
            ResetUI();
            if(!isLoad) SaveAbility();
        }
    }
    

    private void ResetUI()
    {
        costText.text = Convertor.FloatToDolar(cost);
        levelText.text = level.ToString() + " LVL";
    }

    public void IsCostBiggerThanMoney(){
        if(cost < GameManager.Instance().money){
            buyButton.interactable = true;
        }else{
            buyButton.interactable = false;
        }
    }

    private void SaveAbility() => SaveManager.Instance().SaveAbility(id, level);
    
    public void LoadAbility(int loadLevel, bool isSushi = false) {
        if(isSushi) {
            LoadAsSushi();
            return;
        }
        for(int i = 0; i < loadLevel; i++) Buy(true);
    }
    
    private void LoadAsSushi(){
        level = SaveManager.Instance().saveData.myDesk.Count();
        Debug.Log(level.ToString() + " my level.");
        ResetUI();
    }

    public abstract void OnBuy();

    
}
