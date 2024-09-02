using TMPro;
using UnityEngine;

public sealed class JuiceManager : MonoBehaviour
{
    
    private static JuiceManager instance = null;

    public static JuiceManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<JuiceManager>() as JuiceManager;
        return instance;
    }

    private void OnEnable(){
        instance = this;
    }

    [SerializeField] private GameObject juicyText;

    public void click() => TextEffect("+" + BallManager.Instance().ballsCount.ToString(), MousePosition.GetMousePosInWorldSpace(), Color.black);
    
    public void TextEffect(string text = "Adana", Vector3 pos = new Vector3(), Color textColor = new Color()){
        GameObject textObject = Instantiate(juicyText, Vector3.zero, Quaternion.identity, this.transform);
        textObject.GetComponent<TMP_Text>().text = text;
        textObject.GetComponent<TMP_Text>().color = textColor;
        textObject.transform.position = pos;
    }
}
