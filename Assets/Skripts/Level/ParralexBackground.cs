using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ParralexBackground : MonoBehaviour
{
    private float lenght;
    private float startpos;
    [SerializeField]private float parallexEffect;
    private  Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = FindAnyObjectByType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallexEffect));
        float distance = (cam.transform.position.x * parallexEffect);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);
        if (temp > startpos + lenght) startpos += lenght;
        else if(temp < startpos - lenght) startpos -= temp;
    }
}
