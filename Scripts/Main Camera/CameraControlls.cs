using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    public bool toLeft, toRight, toDown, toScreen, onScreen = false, left = false, right = false, down = false;
    Quaternion to;
    Vector3 downM;

    public GameObject ScreenButton;

    void Update()
    {
        if (toLeft || toRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, to, Time.deltaTime * 10);
        }
        if (toDown || toScreen)
        {
            transform.position = Vector3.Lerp(transform.position, downM, Time.deltaTime * 10);
        }
    }

    public void rotateLeft()
    {
        toLeft = true;
        toRight = false;
        if (right)
        {
            to = Quaternion.Euler(0, 180, 0);
            right = false;
        }
        else
        {
            to = Quaternion.Euler(0, 135, 0);
            left = true;
        }
    }

    public void rotateRight()
    {
        toRight = true;
        toLeft = false;

        if (left)
        {
            to = Quaternion.Euler(0, 180, 0);
            left = false;
        }
        else
        {
            to = Quaternion.Euler(0, 225, 0);
            right = true;
        }
    }

    public void moveDown()
    {
        if (onScreen)
        {
            downM = new Vector3(-2.883f, 1.287f, 3.955f);
            onScreen = false;
            ScreenButton.SetActive(true);
        }
        else if (!down)
        {
            downM = new Vector3(-2.883f, 1, 3.5f);
            down = true;
            onScreen = false;
        }
        else
        {
            downM = new Vector3(-2.883f, 1.287f, 3.955f);
            down = false;
            onScreen = false;
        }
        toDown = true;
    }

    public void screenMove()
    {
        if (!onScreen)
        {
            downM = new Vector3(-2.883f, 1.287f, 3.22f);
            onScreen = true;
            down = false;
            ScreenButton.SetActive(false);
        }
        toScreen = true;
    }
}
