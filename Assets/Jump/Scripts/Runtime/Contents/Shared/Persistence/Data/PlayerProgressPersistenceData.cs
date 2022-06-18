using System;
using System.Text;

namespace Template.Contents.Shared.Persistence.Data
{
    [Serializable]
    public sealed class PlayerProgressPersistenceData
    {
        public int GamesPlayed { get; set; } = 0;
        public int MaxPoints { get; set; } = 0;

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{nameof(GamesPlayed)}:{GamesPlayed}");
            stringBuilder.AppendLine($"{nameof(MaxPoints)}:{MaxPoints}");

            return stringBuilder.ToString();
        }
    }
}