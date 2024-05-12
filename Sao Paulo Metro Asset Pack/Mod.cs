using Colossal.Logging;
using Game;
using Game.Modding;
using Game.SceneFlow;
using System.IO;

namespace Sao_Paulo_Metro_Asset_Pack
{
    public class Mod : IMod
    {
        public static ILog log = LogManager.GetLogger($"{nameof(Sao_Paulo_Metro_Asset_Pack)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        private string pathToModFolder;

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));
            if (!GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset)) return;

            pathToModFolder = $"{new FileInfo(asset.path).DirectoryName}";
         
            ExtraAssetsImporter.EAI.LoadCustomAssets(pathToModFolder);
        }

        public void OnDispose()
        {
            ExtraAssetsImporter.EAI.UnLoadCustomAssets(pathToModFolder);
            log.Info(nameof(OnDispose));
        }
    }
}
