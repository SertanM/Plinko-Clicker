using System.Collections.Generic;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    private static SushiManager instance = null;

    public static SushiManager Instance(){
        if(instance==null) instance = new GameObject().AddComponent<SushiManager>();
        return instance;
    }

    private void OnEnable(){
        instance = this;
    }

    [SerializeField] private GameObject bars;


    public void LoadSushi(List<int> ids){
        foreach(int id in ids){
            switch(id){
                case 0:
                    bars.SetActive(true);
                    break;
                case 1:
                    BallManager.Instance().ballsCount = 2;
                    break;
                case 2:
                    BallManager.Instance().canBallBeTrick = true;
                    break;
                case 3:
                    PassiveIncreasesManager.multiplier += 2;
                    break;
                case 4:
                    BallManager.Instance().ballsX += 2;
                    break;
                default:
                    Debug.LogError(id.ToString() + " number ID is empty!");
                    break;
            }
            CardManager.Instance().CardWasPressed(id);
        }
    }
}
