using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrow;
    public Transform StartposArrow;
    public GameObject trap;
    [SerializeField] private float speed;
    private bool HasEntered;
    public GameObject rageMode;
   
    // Start is called before the first frame update
    void Start()
    {
       arrow.transform.position = StartposArrow.transform.position;
        PlayerDeath playerdeath = FindObjectOfType<PlayerDeath>();
        playerdeath.playerdied += ResetObjects;
    }

    // Update is called once per frame
    void Update()
    {
        if (HasEntered)
        {
            MoveArrowToPlayer();
            rageMode.SetActive(true);
            Invoke(nameof(SetRageFalse), 0.15f);
            Debug.Log("Set Ragemode false");
        }

        if(arrow.transform.position == trap.transform.position)
        {
            rageMode.SetActive(false);
            arrow.gameObject.SetActive(false);
            enabled = false;

        }
    }
    private void ResetObjects()
    {
        HasEntered = false;
        arrow.SetActive(true);
        enabled = true;
        arrow.transform.position = StartposArrow.transform.position;
        if(rageMode != null) 
            rageMode.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HasEntered = true;
    }

    private void SetRageFalse()
    {
       rageMode.SetActive(false);
    }
    public void MoveArrowToPlayer()
    {
        arrow.transform.position = Vector2.MoveTowards(arrow.transform.position, trap.transform.position, speed * Time.deltaTime);

        // Vector3 direction = (player.transform.position - arrow.transform.position).normalized;
        // arrow.transform.Translate(direction * speed * Time.deltaTime);
    }
}
