using Juce.CoreUnity.Persistence.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Shared.Persistence.Data;

namespace Template.Contents.Services.Persistence.Services
{
    public interface IPersistenceService 
    {
        ISerializableData<PlayerProgressPersistenceData> PlayerProgress { get; }

        Task Load(CancellationToken cancellationToken);
    }
}