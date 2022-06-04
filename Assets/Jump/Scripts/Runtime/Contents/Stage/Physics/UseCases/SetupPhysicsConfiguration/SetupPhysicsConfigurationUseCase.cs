using UnityEngine;

namespace Template.Contents.Stage.Physics.UseCases.SetupPhysicsConfiguration
{
    public sealed class SetupPhysicsConfigurationUseCase : ISetupPhysicsConfigurationUseCase
    {
        private readonly float physicsGravity;

        public SetupPhysicsConfigurationUseCase(
            float physicsGravity
            )
        {
            this.physicsGravity = physicsGravity;
        }

        public void Execute()
        {
            UnityEngine.Physics.gravity = new Vector3(0, physicsGravity, 0);
        }
    }
}
