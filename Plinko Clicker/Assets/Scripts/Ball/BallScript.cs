using UnityEngine;

public sealed class BallScript : MonoBehaviour
{
    public int x = 1; 

    private void OnTriggerEnter2D(Collider2D coll){
        if(coll.TryGetComponent<WinField>(out var win)){
            GameManager.Instance().AddMoney(win.Touched() * x);
            if(win.Touched() > 0f) JuiceManager.Instance().TextEffect(Convertor.FloatToDolar(win.Touched() * x), this.transform.position, Color.green);
            Destroy(this.gameObject);
        }
    }

    
}
