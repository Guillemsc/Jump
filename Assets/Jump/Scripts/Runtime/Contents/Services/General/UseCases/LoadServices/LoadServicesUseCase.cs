using System.Threading;
using System.Threading.Tasks;
using Template.Contents.Services.Persistence.Services;

namespace Template.Contents.Services.General.UseCases.LoadServices
{
    public class LoadServicesUseCase : ILoadServicesUseCase
    {
        private readonly IPersistenceService persistenceService;

        public LoadServicesUseCase(
            IPersistenceService persistenceService
            )
        {
            this.persistenceService = persistenceService;
        }

        public async Task Execute(CancellationToken cancellationToken)
        {
            await persistenceService.Load(cancellationToken);
        }
    }
}
