using UnityEngine;
using System.IO;
using System.Linq;
public class SaveManager : MonoBehaviour
{
    [SerializeField] private AbillityManager[] abilities;
    public SaveData saveData;
    private static SaveManager instance = null;
    private void OnEnable(){
        instance = this;
    }

    private void Start(){
        Load();
    }

    public static SaveManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<SaveManager>();
        return instance;
    }

    [ContextMenu("Save")]
    private void Savedata(){
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(Application.persistentDataPath + "/SaveData.json", json);
    }

    public void SaveMoney(float money){
        saveData.money = money;
        Savedata();
    }

    public void SaveAbility(int id,int level)
    {
        if(id==9) return;
        saveData.abilityLevels[id] = level;
        Savedata();
    }

    public void SaveCard(int id){
        saveData.myDesk.Add(id);
        Savedata();
    }



    private void Load(){
        LoadData();
        LoadMoney();
        LoadAbilities();
        LoadSushi();
        RestartUI();
    }

    private void LoadData(){
        string json = File.ReadAllText(Application.persistentDataPath +  "/SaveData.json");
        saveData = JsonUtility.FromJson<SaveData>(json);
    }

    private void LoadMoney()
    {
        GameManager.Instance().money = saveData.money;
    }

    private void LoadAbilities()
    {
        for(int i = 0; i < abilities.Count(); i++) abilities[i].LoadAbility(saveData.abilityLevels[i], i==9);
    }

    private void LoadSushi()
    {
        SushiManager.Instance().LoadSushi(saveData.myDesk);
    }

    private void RestartUI(){
        GameManager.Instance().RestartUI();
    }

    public void RestartAllSavedData()
    {
        saveData.abilityLevels = new int[10];
        saveData.money = 0f;
        Savedata();
    }
}
