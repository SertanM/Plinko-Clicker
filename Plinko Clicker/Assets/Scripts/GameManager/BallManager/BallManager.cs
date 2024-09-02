using UnityEngine;

public sealed class BallManager : MonoBehaviour
{
    private static BallManager instance = null;
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject ballX;
    public float ballsMoney = .3f;
    public int ballsX = 1;
    public int ballsCount = 1;
    public bool canBallBeTrick = false;
    private int trickCounter = 0;

    private void OnEnable(){
        instance = this;
    }

    public static BallManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<BallManager>();
        return instance;
    }

    public void AddBallInArea(){
        for(int i = 0; i < ballsCount; i++){
            if(canBallBeTrick && trickCounter%2==0) AddBallX(1, Color.black, true);
            else Instantiate(ball, new Vector3(Random.Range(4.3f, 4.7f), 3f, 0f), Quaternion.identity, this.transform).GetComponent<BallScript>().x *= ballsX;
        }
        
        trickCounter++;
    }

    public void AddBallInArea(int x, Color ballColor, bool isTrickBall){
        for(int i = 0; i < ballsCount; i++){
            AddBallX(x, ballColor, isTrickBall);
        }
    }

    private void AddBallX(int x, Color ballColor, bool isTrickBall){
        BallScript ball = Instantiate(ballX, new Vector3(Random.Range(4.3f, 4.7f), 3f, 0f), Quaternion.identity, this.transform).GetComponent<BallScript>();
        ball.x = x * ballsX;
        ball.transform.GetComponent<SpriteRenderer>().color = ballColor;
        if(isTrickBall) ball.gameObject.layer = LayerMask.NameToLayer("Trick");
    }
}
