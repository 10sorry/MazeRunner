using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _step;
    public level2 _level2;
    public AudioSource stepsSource;
    public bool isOnLevel3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            TryMove(Vector3.forward);

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            TryMove(Vector3.back);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            TryMove(Vector3.right);

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            TryMove(Vector3.left);

    }

    private void TryMove(Vector3 direction)
    {
        var forwardRay = new Ray(transform.position, direction);

        if (Physics.Raycast(forwardRay, out RaycastHit hit, _step, _obstacleMask))
            return;

        transform.forward = direction;
        stepsSource.Play();
        transform.Translate(direction * _step, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("false") && isOnLevel3)
        {
            Debug.Log("Player is on platform");
            _level2.Lose();
        }
    }
}    
