using UnityEngine;
using DG.Tweening;
using TMPro;

public sealed class GoUp : MonoBehaviour
{
    private void Start(){
        this.GetComponent<RectTransform>().DOAnchorPosY(this.GetComponent<RectTransform>().anchoredPosition.y + .8f, .8f);
        this.GetComponent<TMP_Text>().DOFade(0f, .8f).OnComplete(()=> { Destroy(this.gameObject); });
    }
}
