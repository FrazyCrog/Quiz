using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBackgroundColor : MonoBehaviour
{
    [SerializeField] private Color[] colors;
    void Start()
    {
        if(colors.Length == 0) return;
        
        transform.GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
    }
    
}
