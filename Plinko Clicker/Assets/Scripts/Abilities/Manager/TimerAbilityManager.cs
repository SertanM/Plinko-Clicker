using UnityEngine;
using UnityEngine.UI;

public abstract class TimerAbilityManager : AbillityManager 
{
    private bool isStarted = false;

    [Header("--------------Timer Settings--------------")]
    [SerializeField] private Image bar;
    [SerializeField] private float timeDivider = 8f;
    [SerializeField] protected float maxTime = 5f;
    private float myTime = 0f;

    public override void OnBuy(){
        if(!isStarted) {
            isStarted = true;
            Debug.Log(isStarted);
            return;
        }
        maxTime -= maxTime / timeDivider;
        myTime = maxTime;
        OnUpgrade();
    }


    private void Start() => myTime = maxTime;


    private void Update()
    {
        if(!isStarted) return;

        if(myTime>0){
            myTime-=Time.deltaTime;
        }else{
            myTime = maxTime;
            OnTimerEnd();
        }

        bar.fillAmount = (maxTime - myTime) / maxTime;
    }

    public abstract void OnTimerEnd();

    public virtual void OnUpgrade(){}
}
