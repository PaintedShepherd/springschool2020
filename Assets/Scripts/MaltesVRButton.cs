using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MaltesVRButton : MonoBehaviour
{
    public Color colorActivated;
    public float hilightValue = 0.2f;
    public GameObject buttonObject;
    public GameObject buttonTarget;
    private bool isButtonActive;
    private bool isButtonHighlighted;
    public bool isSwitchButton = true;
    public UnityEvent onActivated;
    public UnityEvent onDeactivated;

    private Color colorDeactivated;
    private Color colorHighlightActivated;
    private Color colorHighlightDeactivated;
    private Vector3 buttonPosition;



    // Start is called before the first frame update
    void Start()
    {
        colorDeactivated = buttonObject.GetComponent<Renderer>().material.color;
        colorHighlightActivated = colorActivated + new Color(hilightValue, hilightValue, hilightValue);
        colorHighlightDeactivated = colorDeactivated + new Color(hilightValue, hilightValue, hilightValue);

        buttonPosition = buttonObject.transform.position;

        setButtonHighlight(isButtonHighlighted);
        setButtonState(isButtonActive);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pressButton()
    {
        if (isSwitchButton)
        {
            if (!isButtonActive)
            {
                buttonObject.transform.position = buttonTarget.transform.position;
            }
            else
            {
                buttonObject.transform.position = buttonPosition;
            }
        }
        else
        {
            buttonObject.transform.position = buttonTarget.transform.position;
        }

        setButtonState(!isButtonActive);
    }

    public void releaseButton()
    {
        if (!isSwitchButton)
        {
            Debug.Log("MaltesVRButton releaseButton");

            buttonObject.transform.position = buttonPosition;

            setButtonState(!isButtonActive);
        }
    }

    public void setButtonState(bool state)
    {
        isButtonActive = state;

        if (isButtonActive)
        {

            onActivated.Invoke();
        }
        else
        {

            onDeactivated.Invoke();
        }

        setButtonHighlight(isButtonHighlighted);
    }

    public void setButtonHighlight(bool _isButtonHighlighted)
    {
        isButtonHighlighted = _isButtonHighlighted;

        if (isButtonHighlighted)
        {
            if (isButtonActive)
            {
                buttonObject.GetComponent<Renderer>().material.color = colorHighlightActivated;

            }
            else
            {
                buttonObject.GetComponent<Renderer>().material.color = colorHighlightDeactivated;
            }
        }
        else
        {
            if (isButtonActive)
            {
                buttonObject.GetComponent<Renderer>().material.color = colorActivated;

            }
            else
            {
                buttonObject.GetComponent<Renderer>().material.color = colorDeactivated;
            }
        }
    }
}
