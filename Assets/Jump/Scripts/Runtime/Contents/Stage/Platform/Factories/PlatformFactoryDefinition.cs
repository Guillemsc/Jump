namespace Template.Contents.Stage.Platform.Factories
{
    public sealed class PlatformViewFactoryDefinition
    {
        public int PlatformIndex { get; }

        public PlatformViewFactoryDefinition(
            int platformIndex
            )
        {
            PlatformIndex = platformIndex;
        }
    }
}
