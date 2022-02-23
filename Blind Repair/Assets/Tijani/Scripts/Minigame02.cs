using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Minigame02 : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _target;
    [Range(0f, 20f)] [SerializeField] private float _randomMin, _randomMax;

    [SerializeField] private float _playerSpeed;
    [SerializeField] private UnityEvent _event;

    private Vector3 _input;

    private void Start()
    {
        SetPosition();
    }

    private void Update()
    {
        MovePlayer();

        var distancePlayerTarget = Vector3.Distance(_player.transform.position, _target.transform.position);
        _source.pitch = distancePlayerTarget / 50f;
        _source.pitch = Mathf.Clamp(_source.pitch, 0f, 1f );

        if (distancePlayerTarget < .5f)
        {
             _event.Invoke();
        }
    }

    private void MovePlayer()
    {
        _input = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _input.z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _input.z = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _input.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _input.x = -1;
        }

        var playerPos = _player.transform.position;
        playerPos += _input.normalized * _playerSpeed * Time.deltaTime;
        // playerPos.x = Mathf.Clamp(_player.transform.position.x, -20f, 20f);
        // playerPos.y = Mathf.Clamp(_player.transform.position.y, -20f, 20f);
        _player.transform.position = playerPos;
    }

    private Vector3 GivePosition(float min, float max)
    {
        Vector3 randomPos = new Vector3(Random.Range(min, max), 0, Random.Range(min, max));

        return randomPos;
    }

    [ContextMenu("Set Position")]
    public void SetPosition()
    {
        _player.transform.position = GivePosition(_randomMin, _randomMax);
        _target.transform.position = GivePosition(-_randomMin, -_randomMax);
    }
}