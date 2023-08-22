using Kaynir.TDSTest.Agents;

namespace Kaynir.TDSTest.Detection
{
    public interface IDetectable
    {
        bool InStealth { get; }
        Agent Agent { get; }
    }
}