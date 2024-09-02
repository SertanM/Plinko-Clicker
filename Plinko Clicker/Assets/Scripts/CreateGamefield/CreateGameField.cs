using Unity.Mathematics;
using UnityEngine;

public sealed class CreateGameField : MonoBehaviour
{
    [SerializeField] private GameObject pong;
    [SerializeField] private Vector3 startPos;
    [Tooltip("The pong count in first line")] [SerializeField] private int startPongCount = 2;
    [Tooltip("The max pong count in last line")] [SerializeField] private int maxPongCount = 6;

    private void Awake(){
        CreateField();
    }

    private void CreateField(){
        for(int i = startPongCount; i < maxPongCount + 1; i++){
            for(int j = 0; j < i; j++){
                Instantiate(pong, startPos + new Vector3((j * .5f) + ((i - startPongCount) * -.25f) , (i - startPongCount) * - .5f, 0f), quaternion.identity, this.transform);
            }
        }
    }
}
