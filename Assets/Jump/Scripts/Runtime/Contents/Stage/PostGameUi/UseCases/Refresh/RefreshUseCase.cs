using Juce.Core.Extensions;
using System.Threading;
using Template.Contents.Services.Persistence.Services;
using Template.Contents.Stage.Points.Data;
using Template.Contents.Stage.PostGameUi.UseCases.PlayPointsAnimation;

namespace Template.Contents.Stage.PostGameUi.UseCases.Refresh
{
    public class RefreshUseCase : IRefreshUseCase
    {
        private readonly PointsData pointsData;
        private readonly IPersistenceService persistenceService;
        private readonly IPlayPointsAnimationUseCase playPointsAnimationUseCase;

        public RefreshUseCase(
            PointsData pointsData,
            IPersistenceService persistenceService,
            IPlayPointsAnimationUseCase playPointsAnimationUseCase
            )
        {
            this.pointsData = pointsData;
            this.persistenceService = persistenceService;
            this.playPointsAnimationUseCase = playPointsAnimationUseCase;
        }

        public void Execute()
        {
            persistenceService.PlayerProgress.Data.GamesPlayed += 1;

            bool isHighScore = pointsData.Points.Value > persistenceService.PlayerProgress.Data.MaxPoints;

            if(isHighScore)
            {
                persistenceService.PlayerProgress.Data.MaxPoints = pointsData.Points.Value;
            }

            persistenceService.PlayerProgress.Save(CancellationToken.None).RunAsync();

            playPointsAnimationUseCase.Execute(pointsData.Points.Value);
        }
    }
}