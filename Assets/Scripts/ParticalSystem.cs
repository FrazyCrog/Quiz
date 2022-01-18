using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private bool enabledShow;
    

    public void ShowParticals()
    {
        gameObject.SetActive(true);
        transform.position = Input.mousePosition;
        animator.Play(0);
    }
}
