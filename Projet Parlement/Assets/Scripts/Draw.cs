using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw : MonoBehaviour
{
    Vector2 mousePosition;
    public GameObject Brush;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(Brush, mousePosition, Quaternion.identity);
        }
    }
}
