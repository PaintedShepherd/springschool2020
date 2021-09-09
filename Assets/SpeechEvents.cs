using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechEvents : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Text textBox;
    public Canvas speechBubbleCanvas;
    private int bubbleIndex = -1;
    public List<SpeechBubble> speechBubbles;
    private bool isTalking = false;
    private int nextTextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.audioSource.clip = this.audioClip;
        this.speechBubbleCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isTalking)
        {
            if (this.audioSource.time >= this.nextTextTime)
            {
                this.ShowNextBubble();
            }
        }
    }

    public void StartTalking()
    {
        if (!this.isTalking)
        {
            this.speechBubbleCanvas.gameObject.SetActive(true);
            this.isTalking = true;
            this.audioSource.Play();
            this.bubbleIndex = -1;
            this.nextTextTime = 0;
            this.ShowNextBubble();
        }
    }

    public void StopTalking()
    {
        if (this.isTalking)
        {
            this.speechBubbleCanvas.gameObject.SetActive(false);
            this.isTalking = false;
            this.audioSource.Stop();
            this.bubbleIndex = -1;
            this.nextTextTime = 0;
        }
    }

    public void ShowBubble(int _bubbleIndex)
    {
        this.textBox.text = this.speechBubbles[_bubbleIndex].text;
    }

    public void ShowNextBubble()
    {
        if (this.bubbleIndex < this.speechBubbles.Count - 1)
        {
            this.bubbleIndex++;
            this.ShowBubble(this.bubbleIndex);
            this.nextTextTime = this.nextTextTime += this.speechBubbles[this.bubbleIndex].SecondToShow;
        }
    }
}
