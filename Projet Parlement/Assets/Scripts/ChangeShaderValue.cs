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
    public Direction direction;
    public DirectionStruct[] directionValue;

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
            //print(Vector3.Distance(lastPosition, Input.mousePosition));
            print((lastPosition - Input.mousePosition).normalized);


            if (Vector3.Distance(lastPosition,Input.mousePosition)>=tolerance)
            {
                var MovementDirection = (lastPosition - Input.mousePosition).normalized;
                var isMovementRight = (MovementDirection.x < -0.8 && MovementDirection.y > -0.3 && MovementDirection.y < 0.3);
                var isMovementLeft = (MovementDirection.x > 0.8 && MovementDirection.y > -0.3 && MovementDirection.y < 0.3);
                var isMovementUp = (MovementDirection.y < -0.8 && MovementDirection.x > -0.3 && MovementDirection.x < 0.3);
                var isMovementDown = (MovementDirection.y > 0.8 && MovementDirection.x > -0.3 && MovementDirection.x < 0.3);

                foreach (var direction in directionValue)
                {
                    var isDirectionValid = false;
                    if (direction.direction == Direction.right)
                    {
                        isDirectionValid = isMovementRight;
                    }
                    if (direction.direction == Direction.up)
                    {
                        isDirectionValid = isMovementUp;
                    }
                    if (direction.direction == Direction.left)
                    {
                        isDirectionValid = isMovementLeft;
                    }
                    if (direction.direction == Direction.down)
                    {
                        isDirectionValid = isMovementDown;
                    }

                    if (isDirectionValid && value >= direction.MinValue && value <= direction.MaxValue)
                    {
                        value += speed;
                    }
                }

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
