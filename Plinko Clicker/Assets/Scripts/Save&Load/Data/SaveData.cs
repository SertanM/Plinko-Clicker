using System.Collections.Generic;

[System.Serializable]
public class SaveData
{
    public float money = 0f;
    public int[] abilityLevels = new int[10];
    public List<int> myDesk;

    public SaveData(){}

    public SaveData(float money, int[] abilitiyLevels, List<int> myDesk){
        this.money = money;
        this.abilityLevels = abilitiyLevels;
        this.myDesk = myDesk;
    }
}
