using UnityEngine;

namespace FxMachineLib.Core
{
    public class ExplodeChunks : ParticleEffect
    {
        private Transform _tran;

        public void Play(Vector3 pos, Color color)
        {
            transform.position = pos;
            var main = Systems[0].main;
            main.startColor = color;
            PlaySystems();
        }

        protected override void UpdateEffect()
        {
        }
    }
}