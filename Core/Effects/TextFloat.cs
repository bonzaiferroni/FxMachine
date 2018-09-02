using System.Collections;
using TMPro;
using UnityEngine;

namespace FxMachineLib.Core
{
    [RequireComponent(typeof(TextMeshPro))]
    public class TextFloat : BaseEffect
    {
        private float _duration;
        private TextMeshPro _label;
        private Vector3 _position;
        private Color _color;
        private Vector3 _scaleRef;

        internal override void Init()
        {
            _label = GetComponent<TextMeshPro>();
        }

        public void Play(Vector3 position, string msg, Color color)
        {
            if (color == default(Color))
                color = Color.white;
            
            transform.position = position;
            _position = position;
            _label.text = msg;
            _duration = 3;
            _color = color;
            _label.color = _color;
            transform.localScale = Vector3.zero;
            enabled = true;
        }

        private void LateUpdate()
        {

            if (_duration < 0)
            {
                enabled = false;
                Retire();
                return;
            }
            
            Billboard();
            Ascend();
            Grow();

            _duration -= Time.deltaTime;
            
            if (_duration > 2)
                return;

            _color.a = _duration / 2;
            _label.color = _color;
        }

        private void Grow()
        {
            transform.localScale = Vector3.SmoothDamp(transform.localScale, Vector3.one, ref _scaleRef, .2f); 
        }

        private void Ascend()
        {
            transform.position = _position + Vector3.up * (3 - _duration);
        }

        private void Billboard()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
                Camera.main.transform.rotation * Vector3.up);
        }
    }
}