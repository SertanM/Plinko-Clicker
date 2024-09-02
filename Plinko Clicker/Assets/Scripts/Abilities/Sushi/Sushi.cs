using DG.Tweening;
using UnityEngine;

public class Sushi : AbillityManager
{
    [SerializeField] private Transform myCam;


    public override void OnBuy()
    {
        myCam.DOMoveY(12, 0.6f).OnComplete(()=> {
            CardManager.Instance().CreateCards();
        });
    }
}
