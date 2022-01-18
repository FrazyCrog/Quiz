using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ChoosingAnswer : MonoBehaviour
{
    [SerializeField] private Text questionText;
    [SerializeField] private GameEvents gameEvents;
    
    private CardData[] cardsGrid ; // карточки, которые сейчас на сетке
    
    private List<CardData> exceptionCard = new List<CardData>(); // карточки, которые уже были
    private CardData correctCardData; // верный ответ
    private int idGrid; // ячейка с правильным ответом

    private int randIdCorrect;
    private int randBundles;
    
    /// <summary>
    /// Генерирует ответы
    /// </summary>
    public List<CardData> GetCardData(CardBundleData[] _bundles, int _countRow)
    {
        cardsGrid = new CardData[_countRow * 3];

        randBundles = Random.Range(0,_bundles.Length);
        GeneratesCorrectAnswer(_bundles, _countRow);


        int max = _countRow * 3;
        for (int i = 0; i < max;i++)
        {
            if (i != randIdCorrect)
            {
                int rand = Random.Range(0, _bundles[randBundles].CardData.Length);
                if (!cardsGrid.Contains(_bundles[randBundles].CardData[rand]))
                {
                    cardsGrid[i] = _bundles[randBundles].CardData[rand];
                }
                else
                {
                    i--;
                }
            }
        }

        return cardsGrid.ToList();
    }

    public void ClearException()
    {
        exceptionCard.Clear();
    }

    private void GeneratesCorrectAnswer(CardBundleData[] _bundles, int _countRow)
    {
        randIdCorrect = Random.Range(0, _countRow * 3);
        int randCorrectCardData = Random.Range(0, _bundles[randBundles].CardData.Length);

        if (!exceptionCard.Contains(_bundles[randBundles].CardData[randCorrectCardData])) // при условии, что этого ответа еще не было
        {
            correctCardData = _bundles[randBundles].CardData[randCorrectCardData];
            cardsGrid[randIdCorrect] = correctCardData;
            questionText.text = "Find " + correctCardData.Identifier;
            exceptionCard.Add(correctCardData);
        }
        else
        {
            GeneratesCorrectAnswer(_bundles, _countRow);
        }
    }


    /// <summary>
    /// Возвращает карточку с правильным ответом
    /// </summary>
    /// <returns></returns>
    public CardData GetCorrectCardData()
    {
        exceptionCard.Add(correctCardData); // добавляем в исключение, чтобы дальше эта карточка не показывалась
        return correctCardData;
    }

    
    /// <summary>
    /// Проверка на правильность ответа
    /// </summary>
    /// <returns></returns>
    public bool isCorrectAnswer(CardData _cardData)
    {
        if (_cardData.Identifier == correctCardData.Identifier)
        {
            gameEvents.NextLevelEvent?.Invoke();
            return true;
        }

        return false;
    }
}
