using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Minigame01 : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [Tooltip("Has to be bigger than 1")]
    [SerializeField] private float _minTime, _maxTime;
    [SerializeField] private float _timeToReact;
    [SerializeField] private UnityEvent _event;

    private bool _canPress;
    private IEnumerator _playBeep;

    private void Start()
    {
        // StartCoroutine(PlayBeep());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playBeep = PlayBeep();
            StartCoroutine(_playBeep);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(_playBeep);
            if (_canPress)
            {
                print("you pressed at the right time bud");
            }
            else if (!_canPress)
            {
                print("you missed dumbass");
                _event.Invoke();
            }
        }
    }

    private IEnumerator PlayBeep()
    {
        _canPress = false;
        var randomTime = Random.Range(_minTime, _maxTime);

        yield return new WaitForSeconds(randomTime);

        _source.PlayOneShot(_source.clip);
        StartCoroutine(ReactOnTime());
    }

    private IEnumerator ReactOnTime()
    {
        yield return new WaitForSeconds(_timeToReact);

        _canPress = true;
    }
}