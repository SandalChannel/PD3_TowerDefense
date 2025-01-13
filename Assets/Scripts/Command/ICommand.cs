namespace Command
{
    public interface ICommand
    {
        float Timestamp { get; set; }

        void Execute();
    }
}
