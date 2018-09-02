using UnityEngine;

namespace FxMachineLib.Core
{
    public class ChargeEnergy : ParticleEffect
    {
        private Transform _tran;
        private Vector3 _offset;

        public void Play(Transform tran, Vector3 offset, Color color, float duration)
        {
            _tran = tran;
            _offset = offset;
            var main = Systems[0].main;
            main.startColor = color;
            main.duration = duration;
            PlaySystems();
        }
        
        protected override void UpdateEffect()
        {
            transform.position = _tran.position + _offset;
        }
    }
}