using UnityEngine;

namespace FxMachineLib.Core
{
    public class RadarHit : ParticleEffect
    {
        public void Play(Vector3 position, float height)
        {
            transform.position = new Vector3(position.x, height, position.z);
            PlaySystems();
        }

        protected override void UpdateEffect()
        {
        }
    }
}