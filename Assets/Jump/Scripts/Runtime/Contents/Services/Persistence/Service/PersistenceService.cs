using Juce.CoreUnity.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Persistence.Data;

namespace Template.Contents.Services.Persistence.Services
{
    public class PersistenceService : IPersistenceService
    {
        public ISerializableData<PlayerProgressPersistenceData> PlayerProgress { get; }
            = new SerializableData<PlayerProgressPersistenceData>("PlayerProgress");

        public async Task Load(CancellationToken cancellationToken)
        {
            await PlayerProgress.Load(cancellationToken);
        }
    }
}