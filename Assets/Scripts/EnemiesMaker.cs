using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesMaker : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delay;
    
    private const float MinTimeBetweenIterations = 0.1f;

    private List<Transform> _points;

    private void OnValidate()
    {
        if (_delay < MinTimeBetweenIterations)
        {
            _delay = MinTimeBetweenIterations;
        }
    }

    private void Start()
    {
        _points = GetComponentsInChildren<Transform>().ToList();

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        var wait = new WaitForSeconds(_delay);
        
        while (_points.Count > 0)
        {
            int randomNumber = Random.Range(0, _points.Count);
            Instantiate(_enemy, _points[randomNumber], false);
            
            _points.RemoveAt(randomNumber);
            yield return wait;
        }
    }
}
