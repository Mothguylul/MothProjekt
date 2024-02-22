using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plattform : MonoBehaviour
{

    public BoxCollider2D boxCollider;
    public Transform border;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > border.transform.position.y)
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
