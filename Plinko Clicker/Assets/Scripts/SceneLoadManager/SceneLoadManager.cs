using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
public class SceneLoadManager : MonoBehaviour
{
    private static SceneLoadManager instance = null;
    [SerializeField] private Transform dot;
    public static SceneLoadManager Instance(){
        if(instance==null) instance = new GameObject().AddComponent<SceneLoadManager>();
        return instance;
    }

    private void OnEnable(){
        instance = this;
        dot.DOScale(0f, .4f).SetEase(Ease.Linear);
    }

    public void LoadScene(int sceneNum){
        dot.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0f);
        dot.DOScale(24f, .4f).OnComplete(() => {SceneManager.LoadScene(sceneNum);}).SetEase(Ease.Linear);
    }
}
