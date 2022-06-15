﻿using Template.Contents.Stage.StageUi.UseCases.SetPoints;

namespace Template.Contents.Stage.StageUi.Interactor
{
    public class StageUiInteractor : IStageUiInteractor
    {
        private readonly ISetPointsUseCase setPointsUseCase;

        public StageUiInteractor(
            ISetPointsUseCase setPointsUseCase
            )
        {
            this.setPointsUseCase = setPointsUseCase;
        }

        public void SetPoints(int points)
        {
            setPointsUseCase.Execute(points);
        }
    }
}
