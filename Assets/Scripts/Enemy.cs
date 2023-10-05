using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    [HideInInspector]
    public Transform Target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.position, _speed * Time.deltaTime);
    }
}
