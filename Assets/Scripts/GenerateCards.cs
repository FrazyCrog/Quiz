using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GenerateCards : MonoBehaviour
{
    [SerializeField] private GameEvents gameEvent;

    [SerializeField]
    private CardBundleData[] cardBundleDatas;

    [SerializeField] private Level[] levels;

    [SerializeField] private Transform parent;

    [SerializeField] private GameObject prefabCard;
    
    [SerializeField] private Vector2 Offset;

    [SerializeField] private ChoosingAnswer choosingAnswer;

    private int randIdRardBundle;
    private int level;

    private Coroutine nextLevelCoroutine;
    

    void Start()
    {
        gameEvent.NextLevelEvent.AddListener(NextLevel);
        Generate();
    }
    

    private void NextLevel()
    {
        if (nextLevelCoroutine == null)
        {
               nextLevelCoroutine = StartCoroutine(NextLevelCoroutine());
        }
    }

    public void NewGame()
    {
        level = 0;
        choosingAnswer.ClearException();
        Generate();
    }

    /// <summary>
    /// Генерирует карточки
    /// </summary>
    public void Generate()
    {
        ClearGrid();
        
        List<CardData> cardsData = choosingAnswer.GetCardData(cardBundleDatas, levels[level].CountRows); // список с вариантами ответа

        for(int i = 0; i < levels[level].CountRows * 3; i++)
        {
            GameObject card = Instantiate(prefabCard, parent.position, Quaternion.identity);
            card.transform.SetParent(parent.transform);
            card.transform.localScale = new Vector3(1, 1, 1);
            card.GetComponent<Card>().Initialization(cardsData[i], choosingAnswer);
        }

        SetScale();
    }

    /// <summary>
    /// Подстраивает размер сетки под карточки
    /// </summary>
    private void SetScale()
    {
        parent.GetComponent<RectTransform>().sizeDelta = new Vector2(780 + Offset.x, 250 * levels[level].CountRows + Offset.y);
    }

    /// <summary>
    /// Очищает сетку
    /// </summary>
    public void ClearGrid()
    {
        for(int i = 0; i < parent.childCount; i++)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
    }

    private IEnumerator NextLevelCoroutine()
    {
        yield return new WaitForSeconds(1f);
        if (level + 1 < levels.Length)
        {
            level++;
            Generate();
        }
        else
        {
            gameEvent.VictoryEvent?.Invoke();
        }

        nextLevelCoroutine = null;
    }
}
