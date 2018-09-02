using UnityEngine;
using UnityEngine.UI;

namespace FxMachineLib.Core
{
    public static class FxMachine
    {
        public static void RadarSweep(Transform origin, float size, float height = 0)
        {
            var originEffect = FxFactory.GetEffect<RadarSweep>();
            originEffect.Play(origin, size, height);
        }

        public static void RadarHit(Vector3 position, float height = 0)
        {
            var hitEffect = FxFactory.GetEffect<RadarHit>();
            hitEffect.Play(position, height);
        }

        public static void EnergyTransfer(Vector3 origin, Vector3 destination, float amount)
        {
            var effect = FxFactory.GetEffect<EnergyTransfer>();
            effect.Play(origin, destination, amount);
        }

        public static void TextFloat(Vector3 position, string msg, Color color = default(Color))
        {
            var effect = FxFactory.GetEffect<TextFloat>();
            effect.Play(position, msg, color);
        }

        public static void TextFloatCanvas(Graphic graphic, string msg, Color color = default(Color))
        {
            TextFloatCanvas(graphic.canvas, graphic.transform.position, msg, color);
        }

        public static void TextFloatCanvas(Canvas canvas, Vector3 position, string msg, Color color = default(Color))
        {
            var effect = FxFactory.GetEffect<TextFloatCanvas>();
            effect.Play(canvas, position, msg, color);
        }

        public static void BeamEffect(Vector3 startPos, Vector3 endPos, Color color)
        {
            var effect = FxFactory.GetEffect<BeamEffect>();
            effect.Play(startPos, endPos, color);
        }

        public static void ChargeEnergy(Transform tran, Vector3 offset, Color color, float duration)
        {
            var effect = FxFactory.GetEffect<ChargeEnergy>();
            effect.Play(tran, offset, color, duration);
        }

        public static void ExplodeChunks(Vector3 position, Color color)
        {
            var effect = FxFactory.GetEffect<ExplodeChunks>();
            effect.Play(position, color);
        }
    }
}