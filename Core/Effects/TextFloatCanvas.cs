using TMPro;
using UnityEngine;

namespace FxMachineLib.Core
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    [RequireComponent(typeof(RectTransform))]
    public class TextFloatCanvas : BaseEffect
    {
        private float _duration;
        private TextMeshProUGUI _label;
        private Vector2 _position;
        private Color _color;
        private Vector3 _scaleRef;
        private RectTransform _rect;

        internal override void Init()
        {
            _label = GetComponent<TextMeshProUGUI>();
            _label.raycastTarget = false;
            _rect = GetComponent<RectTransform>();
        }

        public void Play(Canvas canvas, Vector3 position, string msg, Color color)
        {
            if (color == default(Color))
                color = Color.white;
            
            transform.SetParent(canvas.transform, false);
            
            transform.position = position;
            _position = _rect.anchoredPosition;
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
            _rect.anchoredPosition = _position + Vector2.up * (3 - _duration) * 10;
        }
    }
}