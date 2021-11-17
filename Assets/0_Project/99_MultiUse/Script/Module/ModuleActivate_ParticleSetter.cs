using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ToronPuzzle
{
    public class ModuleActivate_ParticleSetter : MonoBehaviour
    {
        [SerializeField]
        List<ParticleSystem> _particleSystems;
        public void SetAllParticleColor(Color _argColor)
        {
            foreach (ParticleSystem _particle in _particleSystems)
                _particle.startColor = _argColor;
        }

    }
}