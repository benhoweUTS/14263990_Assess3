using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;
    private AudioSource pacAudio;
    [SerializeField] private AudioClip pacMove;
    
    // Start is called before the first frame update
    void Start()
    {
        pacAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (activeTween == null)
        {
            if (pacAudio.isPlaying)
            {
                pacAudio.Stop();
            }
            return;
        }
        if (Vector3.Distance(activeTween.EndPos, activeTween.Target.position) > 0.1f)
        {
            //var timeFraction = (Time.fixedTime - activeTween.StartTime) / activeTween.Duration;
            //activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            activeTween.Target.position = Vector3.MoveTowards(activeTween.Target.position, activeTween.EndPos,
                Time.deltaTime * activeTween.Speed);
        }
        else
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween = null;
        }
    }

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            
            if (pacAudio.isPlaying) { return; }
            pacAudio.clip = pacMove;
            pacAudio.Play();
        }
    }
}
