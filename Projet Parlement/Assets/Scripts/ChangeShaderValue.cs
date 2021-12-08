using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShaderValue : MonoBehaviour
{
    public Material shader;
    public Texture2D image;
    public float value;
    public float tolerance = 2;
    public float speed = 0.1f;
    private Vector3 lastPosition;
    public Renderer parlement;
    public float speedCamera = 2;

    private float t;

    private void Start()
    {
        value = 0;
        shader.SetTexture("_MainTexture", image);
        parlement.enabled = false;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            print(Vector3.Distance(lastPosition, Input.mousePosition));

            if (Vector3.Distance(lastPosition,Input.mousePosition)>=tolerance)
            {
                value += speed;
            }
            lastPosition = Input.mousePosition;
        }
        shader.SetFloat("_FillAmount", value);

        if (value>=1)
        {
            parlement.enabled = true;
            SetRotation();
        }

    }
    private void SetRotation()
    {
        t += Time.deltaTime * speedCamera;
        Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.right * 65), Quaternion.Euler(Vector3.zero), t);
    }


}
