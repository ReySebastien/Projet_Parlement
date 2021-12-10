using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShaderValue : MonoBehaviour
{
    public Material shader;
    public Texture2D image;
    public float value;
    public float tolerance = 2;
    public float speed = 0.1f;
    private Vector3 lastPosition;
    public Renderer parlement;
    public float speedCamera = 0.5f;
    public bool rotationDone = false;
    private bool isCoroutineExecuting = false;
    public float delay = 5f;
    public float timer = 0;
    public bool waitDone = false;
    public Image button;
    public Text buttonText;
    public GameObject activeButton;
    public Image popUp;

    private float t;

    private void Start()
    {
        value = 0;
        shader.SetTexture("_MainTexture", image);
        parlement.enabled = false;
        button.enabled = false;
        buttonText.enabled = false;
        activeButton.SetActive(false);

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

            if (rotationDone == false)
            {
                SetRotation();
            }
        }

            if (waitDone == true)
            {
                ReturnRotation();
                waitDone = false;
            }
    }

    private void SetRotation()
    {
        t += Time.deltaTime * speedCamera;
        Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.right * 65), Quaternion.Euler(Vector3.zero), t);
        StartCoroutine(Wait(delay));
    }

    private void ReturnRotation()
    {
        t += Time.deltaTime * speedCamera;
        Camera.main.transform.rotation = Quaternion.Lerp(Quaternion.Euler(Vector3.zero), Quaternion.Euler(Vector3.right * 65), t);
        popUp.enabled = true;
        button.enabled = true;
        buttonText.enabled = true;
        activeButton.SetActive(true);
        
    }

    IEnumerator Wait(float delay)
    {
        yield return new WaitForSeconds(delay);
        rotationDone = true;
        waitDone = true;
    }
}
