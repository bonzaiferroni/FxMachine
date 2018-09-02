using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FxMachineLib.Core
{
    public class FxMachineTestManager : MonoBehaviour
    {

        private IEnumerator Start()
        {
            while (true)
            {
                BeamEffect();
                EnergyTransfer();
                RadarSweep();
                RadarHit();
                TextFloat();
                TextFloatCanvas();
                yield return new WaitForSeconds(5);
            }
        }
        
        [Header("Beam Effect")] 
        public Transform BeamStart;
        public Transform BeamEnd;
        public Color BeamColor = Color.green;

        private void BeamEffect()
        {
            FxMachine.BeamEffect(BeamStart.position, BeamEnd.position, BeamColor);
        }

        [Header("Energy Transfer")] 
        public Transform EnergyTransferStart;
        public Transform EnergyTransferEnd;
        public float EnergyTransferAmount = 10;

        private void EnergyTransfer()
        {
            FxMachine.EnergyTransfer(EnergyTransferStart.position, EnergyTransferEnd.position, EnergyTransferAmount);
        }

        [Header("Radar Sweep")] 
        public Transform RadarSender;
        public float RadarSize = 10;
        public float RadarHeight = 0;

        private void RadarSweep()
        {
            FxMachine.RadarSweep(RadarSender, RadarSize, RadarHeight);
        }
        
        [Header("Radar Hit")] 
        public Transform RadarTarget;
        public float RadarTargetHeight = 0;

        private void RadarHit()
        {
            FxMachine.RadarHit(RadarTarget.position, RadarTargetHeight);
        }

        [Header("Text Float")] 
        public Transform TextEmitter;
        public string EmitterMsg;
        public Color TextColor;

        private void TextFloat()
        {
            FxMachine.TextFloat(TextEmitter.position, EmitterMsg, TextColor);
        }
        
        [Header("Text Float Canvas")] 
        public Graphic TextEmitterTarget;

        private void TextFloatCanvas()
        {
            FxMachine.TextFloatCanvas(TextEmitterTarget, EmitterMsg, TextColor);
        }
    }
}