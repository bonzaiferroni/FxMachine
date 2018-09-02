using UnityEngine;

namespace FxMachineLib.Core
{
    public abstract class ParticleEffect : BaseEffect
    {
        protected ParticleSystem[] Systems;

        internal override void Init()
        {
            Systems = GetComponents<ParticleSystem>();
        }

        protected void PlaySystems()
        {
            enabled = true;
            foreach (var system in Systems)
            {
                system.Play();
            }
        }

        private bool IsActive()
        {
            foreach (var system in Systems)
            {
                if (system.isPlaying)
                {
                    return true;
                }
            }

            return false;
        }

        protected abstract void UpdateEffect();

        private void Update()
        {
            var active = IsActive();
            if (active)
            {
                UpdateEffect();
            }
            else
            {
                enabled = false;
                Retire();
            }
        }
    }
}