public sealed class SpawnerMachine : Machine
{
    protected override bool SetRun() => GameManager.Instance.GameActive && productCollactableArea.products.Count < productionLimit;
}
