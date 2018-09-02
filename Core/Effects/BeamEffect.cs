using System.Collections;
using UnityEngine;

namespace FxMachineLib.Core
{
    [RequireComponent(typeof(LineRenderer))]
    public class BeamEffect : BaseEffect
    {
        private LineRenderer _lineRenderer;
        
        private const float BeamDuration = 1;
        private const float HalfDuration = BeamDuration / 2;
        private float _time;
        private Vector3 _startPos;
        private Vector3 _endPos;
        
        internal override void Init()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.useWorldSpace = true;
        }

        public void Play(Vector3 startPos, Vector3 endPos, Color color)
        {
            _time = 0f;
            _startPos = startPos;
            _endPos = endPos;
            _lineRenderer.startColor = color;
            _lineRenderer.endColor = color;

            StartCoroutine(Fire());
        }

        private IEnumerator Fire()
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, _startPos);
            while (_time < HalfDuration)
            {
                var factor = _time / HalfDuration;
                var point = (_endPos - _startPos) * factor + _startPos;
                _lineRenderer.SetPosition(1, point);
                _time += Time.unscaledDeltaTime;
                yield return null;
            }
            
            _lineRenderer.SetPosition(1, _endPos);
            while (_time < BeamDuration)
            {
                var factor = (_time - HalfDuration) / HalfDuration;
                var point = (_endPos - _startPos) * factor + _startPos;
                _lineRenderer.SetPosition(0, point);
                _time += Time.unscaledDeltaTime;
                yield return null;
            }
            
            _lineRenderer.enabled = false;
            Retire();
        }
    }
}