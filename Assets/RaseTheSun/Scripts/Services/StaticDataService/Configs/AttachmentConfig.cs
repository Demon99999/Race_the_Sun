using RaseTheSun.Scripts.Data;
using UnityEngine;

namespace RaseTheSun.Scripts.Services.StaticDataService.Configs
{
    [CreateAssetMenu(fileName = "AttachmentConfig", menuName = "StaticData/Create new attachment config", order = 51)]
    public class AttachmentConfig : ScriptableObject
    {
        public UpgradeType AttachmentUpgradeType;
        public Sprite Icon;
        public string Name;
        public string Title;
    }
}
