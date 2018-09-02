using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace FxMachineLib.Core
{
    public static class FxFactory
    {
        private static Dictionary<string, Stack<BaseEffect>> _cache;
        private static Dictionary<string, GameObject> _prefabCache;
        private static Transform _parent;

        internal static T GetEffect<T>() where T : BaseEffect
        {
            if (_cache == null)
                _cache = new Dictionary<string, Stack<BaseEffect>>();

            var effectName = typeof(T).Name;
            
            if (_cache.ContainsKey(effectName))
            {
                if (_cache[effectName].Count > 0)
                    return _cache[effectName].Pop() as T;
            }
            else
            {
                _cache[effectName] = new Stack<BaseEffect>();
            }
            
            var prefab = GetPrefab(effectName);
            if (prefab == null)
            {
                return null;
            }

            if (_parent == null)
                _parent = new GameObject("FxFactory").transform;
            
            var go = Object.Instantiate(prefab, _parent);
            var effect = go.GetComponent<BaseEffect>();
            if (effect)
                effect.Init();

            return effect as T;
        }

        private static GameObject GetPrefab(string effectName)
        {
            if (_prefabCache == null)
                _prefabCache = new Dictionary<string, GameObject>();

            if (!_prefabCache.ContainsKey(effectName))
            {
                var path = $"FxMachine/{effectName}";
                var prefab = Resources.Load(path, typeof(GameObject)) as GameObject;
                if (prefab == null) throw new Exception($"FxMachine {effectName} not found at {path}");
                _prefabCache[effectName] = prefab;
            }

            return _prefabCache[effectName];
        }

        public static void Return(BaseEffect particleEffect)
        {
            var effectName = particleEffect.GetType().Name;
            if (!_cache.ContainsKey(effectName))
                throw new Exception($"FxMachine tried to return an effect with no cache stack: {effectName}");
            
            _cache[effectName].Push(particleEffect);
        }
    }
}