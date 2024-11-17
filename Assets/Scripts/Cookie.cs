using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cookie : MonoBehaviour
{
    public UnityEvent onClick;

    void Update()
    {
        if (transform.localScale.x > 1f)
        {
            transform.localScale -= Vector3.one * 2 * Time.deltaTime;
        }
    }

    void OnMouseDown()
    {
        transform.localScale = Vector3.one * 1.2f;
        onClick.Invoke();
    }
}
