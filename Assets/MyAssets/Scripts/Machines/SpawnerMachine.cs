public sealed class SpawnerMachine : Machine
{
    protected override bool SetRun() => GameManager.Instance.GameActive && mainProductArea.products.Count < productionLimit;
}
