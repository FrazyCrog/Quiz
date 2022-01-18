using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image icon;

    private CardData cardData;
    private ChoosingAnswer choosingAnswer;

    public void Check()
    {
        if (!choosingAnswer.isCorrectAnswer(cardData)) // если ответ не верен
        {
            icon.transform.DOShakeScale(0.25f, 0.7f); // трясем картинку
        }
    }

    public void Initialization(CardData _cardData, ChoosingAnswer _choosingAnswer)
    {
        cardData = _cardData;
        icon.sprite = cardData.Sprite;
        choosingAnswer = _choosingAnswer;
        
        ShowAnimation();
    }

    /// <summary>
    /// Показывает анимацию при спавне
    /// </summary>
    private void ShowAnimation()
    {
        transform.localScale = new Vector3(0, 0, 0);
        transform.DOScale(1, 0.25f);
    }
    
}
