using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField]private GameObject arrow;
    [SerializeField]private Transform StartposArrow;
    [SerializeField]private GameObject trap;
    [SerializeField] private float speed;
    private bool hasEntered;
  
    void Start()
    {
        arrow.transform.position = StartposArrow.transform.position;
        PlayerDeath playerdeath = FindObjectOfType<PlayerDeath>();
        playerdeath.playerdied += ResetObjects;
    }

    void Update()
    {
        if (hasEntered)
        {
            MoveArrowToTrap();         
        }

        if(arrow.transform.position == trap.transform.position)
        {
            arrow.gameObject.SetActive(false);
            enabled = false;
        }
    }

    private void ResetObjects()
    {
        hasEntered = false;
        arrow.SetActive(true);
        enabled = true;
        arrow.transform.position = StartposArrow.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasEntered = true;
    }
    public void MoveArrowToTrap()
    {
        arrow.transform.position = Vector2.MoveTowards(arrow.transform.position, trap.transform.position, speed * Time.deltaTime);
    }
}
