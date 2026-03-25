namespace Aarthificial.Typewriter.Tools
{
    public struct TypewriterWatcher
    {
        private int _lastUpdate;

        public bool ShouldUpdate() => TypewriterDatabase.Instance.HasChangedSince(ref _lastUpdate);
    }
}
