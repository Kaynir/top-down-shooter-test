using UnityEngine;

namespace Kaynir.TDSTest.Detection.Rules
{
    public abstract class DetectionRule : ScriptableObject
    {
        public const string ASSET_MENU_PATH = "Configs/Detection/Rules/";

        public abstract bool IsVisibleTarget(Collider2D target, FieldOfView view);
    }
}