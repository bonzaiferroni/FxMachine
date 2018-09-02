using UnityEngine;

namespace FxMachineLib.Core
{
    public class EnergyTransfer : ParticleEffect
    {
        private Vector3 _destination;
        private float _timeStarted;
        private Vector3 _origin;

        public void Play(Vector3 origin, Vector3 destination, float amount)
        {
            _origin = origin;
            _destination = destination;
            transform.position = origin;
            transform.localScale = Vector3.one * .1f;
            _timeStarted = Time.time;
            var main = Systems[0].main;
            main.maxParticles = (int) amount;
            PlaySystems();
        }

        protected override void UpdateEffect()
        {
            UpdateScale();
            UpdatePosition();
            UpdateRotation();
        }

        private void UpdateRotation()
        {
            var y = transform.rotation.eulerAngles.y + Time.deltaTime * 720f;
            transform.rotation = Quaternion.Euler(0, y, 0);
        }

        private void UpdatePosition()
        {
            var deltaVector = _destination - _origin;
            var timeProgress = Mathf.Min(Time.time - _timeStarted, 1);
            var currentPos = deltaVector * timeProgress;
            transform.position = _origin + currentPos;
        }

        private void UpdateScale()
        {
            var timeElapsed = Time.time - _timeStarted;
            float scale;
            if (timeElapsed < .5)
            {
                scale = timeElapsed / .5f;
            }
            else
            {
                scale = .5f / timeElapsed;
            }

            transform.localScale = Vector3.one * scale;
        }
    }
}