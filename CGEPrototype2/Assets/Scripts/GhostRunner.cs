/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GhostRunner : MonoBehaviour
{
    [SerializeField] private Transform _recordTarget;
    [SerializeField] private GameObject _ghostPrefab;
    [SerializeField, Range(1, 10)] private int _captureEveryNFrames = 2;

    private void Awake() => _system = new ReplaySystem(this);

    private void OnEnable() => FinishLine.Crossed += OnFinishLineCrossed;
    private void OnDisable() => FinishLine.Crossed -= OnFinishLineCrossed;

    private void OnFinishLineCrossed(bool runStarting)
    {
        if (runStarting)
        {
            _system.StartRun(_recordTarget, _captureEveryNFrames, _captureEveryNFrames);
            _system.PlayRecording(RecordingType.Best, Instantiate(_ghostPrefab));
        }
        else
        {
            _system.FinishRun();
            _system.StopReplay();
        }
    }
}
*/