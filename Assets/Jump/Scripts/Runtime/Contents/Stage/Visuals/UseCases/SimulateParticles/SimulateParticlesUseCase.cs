using System.Collections.Generic;
using UnityEngine;

namespace Template.Contents.Stage.Visuals.UseCases.SimulateParticles
{
    public class SimulateParticlesUseCase : ISimulateParticlesUseCase
    {
        private readonly IReadOnlyList<ParticleSystem> particlesToSimulate;

        public SimulateParticlesUseCase(
            IReadOnlyList<ParticleSystem> particlesToSimulate
            )
        {
            this.particlesToSimulate = particlesToSimulate;
        }

        public void Execute()
        {
            foreach (ParticleSystem particle in particlesToSimulate)
            {
                particle.Simulate(200f);

                particle.Play();
            }
        }
    }
}
