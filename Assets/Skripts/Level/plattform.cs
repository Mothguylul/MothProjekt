using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plattform : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    [SerializeField] private Transform border;
    private Transform playerTransform;

    private void Start()
    {
       boxCollider = GetComponent<BoxCollider2D>();
       playerTransform = Game.Player.GetComponent<Transform>(); 
    }

    void Update()
    {
        if (playerTransform.transform.position.y > border.transform.position.y)
            SetColliderTrue();
        else
            boxCollider.enabled = false;
    }
    private void SetColliderTrue()
    {
        Invoke(nameof(SetCollider), 0.1f);
    }

    private void SetCollider()
    {
        boxCollider.enabled = true;
    }
}
