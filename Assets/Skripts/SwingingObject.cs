using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwingingObject : MonoBehaviour
{

    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float angle = 20.0f;

    private float currenAngle = 0;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;

        float angle = Mathf.Sin(timer) * this.angle;
        transform.rotation = Quaternion.Euler(new Vector3(0,0, angle + currenAngle));
    }
}
