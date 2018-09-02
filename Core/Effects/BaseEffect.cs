using UnityEngine;

namespace FxMachineLib.Core
{
    public abstract class BaseEffect : MonoBehaviour
    {
        internal abstract void Init();

        protected void Retire()
        {
            FxFactory.Return(this);
        }
    }
}