using Abstractions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embulance : MonoBehaviour, ISelectable
{
    public Transform PivotPoint => _pivotPoint;

    public float Health => _health;

    public float MaxHealth => _maxHealth;

    public Vector3 RallyPoint { get; set; }
    public Sprite Icon => _icon;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Transform _pivotPoint;
    
    private float _health = 1000;
}
