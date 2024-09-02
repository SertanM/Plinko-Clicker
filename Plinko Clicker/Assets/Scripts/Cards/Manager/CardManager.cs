using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private List<CardData> cardDesk;
    private static CardManager instance = null;

    public static CardManager Instance(){
        if(instance == null) instance = new GameObject().AddComponent<CardManager>();
        return instance;
    }

    private void OnEnable(){
        instance = this;
    }

    public void CreateCards(){
        if(!(cardDesk.Count > 0)) {
            Final();
            return;
        }

        CreateACard();
        CreateACard();
        CreateACard();

        this.transform.DOLocalMoveY(12, 0.6f).OnComplete(() => {
            this.transform.GetChild(1).DOLocalMove(new Vector3(-4f, 0f, 0f), 0.4f);
            this.transform.GetChild(2).DOLocalMove(new Vector3(4f, 0f, 0f), 0.4f);
        });
    }

    private void CreateACard(){
        GameObject card = Instantiate(cardPrefab, new Vector3(0f, 20f, 0f), Quaternion.identity, this.transform);
        card.GetComponent<Card>().SetCard(cardDesk[Random.Range(0, cardDesk.Count)]);
    }

    private void Final() {
        FinalManager.Instance().StartText();
    }
    

    public void CardPressed(int cardID){
        AddCard(cardID);
        RestartGame();
    }

    private void AddCard(int cardID) => SaveManager.Instance().SaveCard(cardID);
    

    public void CardWasPressed(int cardID) => RemoveCard(cardID);
    

    private void RemoveCard(int cardID) {
        foreach(CardData data in cardDesk) {
            if(data.cardID == cardID) {
                cardDesk.Remove(data);
                break;
            }
        }
    }
    

    private void RestartGame() {
        SaveManager.Instance().RestartAllSavedData();
        SceneManager.LoadScene(0);
    }
    
}
