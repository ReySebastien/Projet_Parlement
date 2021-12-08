using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public RectTransform rt;
    // Update is called once per frame
    void Update()
    {
        rt.position = Input.mousePosition;
    }
}
