using UnityEngine;

namespace FxMachineLib.Core
{
    public class RadarSweep : ParticleEffect
    {
        private Transform _origin;
        private float _height;

        public void Play(Transform origin, float size, float height = 0)
        {
            _origin = origin;
            _height = height;
            var shapeModule = Systems[0].shape;
            shapeModule.radius = size / 2;
            var pos = shapeModule.position;
            pos.x = size / 2;
            shapeModule.position = pos;
            PlaySystems();
        }

        protected override void UpdateEffect()
        {
            if (!_origin)
            {
                return;
            }

            var y = transform.rotation.eulerAngles.y + Time.deltaTime * 360;
            if (y > 360)
            {
                y -= 360;
            }

            transform.rotation = Quaternion.Euler(-90, y, 0);
            transform.position = _origin.position + Vector3.up * _height;
        }
    }
}