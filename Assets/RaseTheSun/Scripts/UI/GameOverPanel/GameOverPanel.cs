using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace RaseTheSun.Scripts.UI.GameOverPanel
{
    public class GameOverPanel : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<string, UniTask<GameOverPanel>>
        {
        }
    }
}
