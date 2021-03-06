﻿using RockPaperScissor.Enums;

namespace RockPaperScissor.Players
{
    public abstract class Player : IPlayer
    {
        public virtual AfterRoundCallback callback => null;

        public abstract PlaysEnum Play();
    }
}
