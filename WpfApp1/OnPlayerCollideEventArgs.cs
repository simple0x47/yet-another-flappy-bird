namespace YetAnotherFlappyBird
{
    public class OnPlayerCollideEventArgs
    {
        public ulong Score { get;  }

        public OnPlayerCollideEventArgs(ulong score)
        {
            Score = score;
        }
    }
}
