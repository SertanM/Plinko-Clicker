using System.Collections;
using TMPro;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    private static FinalManager instance = null;

    public static FinalManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<FinalManager>();
        return instance;
    }

    private void OnEnable(){
        instance = this;
        myText = this.GetComponentInChildren<TMP_Text>();
    }

    private TMP_Text myText;
    [SerializeField] private string message = "";

    public void StartText(){
        JuiceManager.Instance().gameObject.SetActive(false);
        StartCoroutine(nameof(WriteText));
    }

    IEnumerator WriteText(){
        foreach(char c in message){
            myText.text += c;
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(.5f);
        SaveManager.Instance().RestartAllSavedData();
        SceneLoadManager.Instance().LoadScene(0);
    }
}
