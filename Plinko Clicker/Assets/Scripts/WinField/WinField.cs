using UnityEngine;

public sealed class WinField : MonoBehaviour
{
    [SerializeField] private float x = 0;

    public float Touched(){
        return BallManager.Instance().ballsMoney * x;
    }
}
