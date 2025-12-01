namespace Ducky.ModProtocols;

public class ModBehaviour : ModBehaviourBase
{
    protected override bool EnableMessageHubHost { get; set; } = true;

    protected override void ModEnabled()
    {
    }

    protected override void ModDisabled()
    {
    }
}
