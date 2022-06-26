using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedView : MonoBehaviour
{
    [SerializeField] private Transform _rootScale;

    public float minScale = 0f;
    public float maxScale = 1f;

    private float _deltaScale;
    private float _speed;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _deltaScale = maxScale - minScale;
        _speed = (maxScale - minScale) * 3f;
    }

    public void Init(float min, float max)
    {
        minScale = min;
        maxScale = max;
        Init();
    }

    void Update()
    {
        float currentScale = minScale + Mathf.PingPong(Time.time * _speed, _deltaScale);
        Vector3 scale = new Vector3(currentScale, currentScale, currentScale);
        _rootScale.localScale = scale;
    }
}
