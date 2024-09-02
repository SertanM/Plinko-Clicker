using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardID = 0;
    private static bool cardWasPressed;

    public void SetCard(CardData card){
        cardID = card.cardID;
        this.GetComponentInChildren<TMP_Text>().text = card.cardName;
    }

    public void Press(){
        CardManager.Instance().CardPressed(cardID);
    }
}
