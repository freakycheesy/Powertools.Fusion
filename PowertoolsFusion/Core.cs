using MelonLoader;
using PowerTools;
using PowerTools.Tools;
using Powertools.Fusion.Tools;
using PowertoolsFusion;

[assembly: MelonInfo(typeof(Powertools.Fusion.Core), "PowertoolsFusion", "1.0.0", "pietr", null)]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]
[assembly: MelonOptionalDependencies("LabFusion")]

namespace Powertools.Fusion
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            ToolLoader.LoadTools(tools);
            if (FindMelon("LabFusion", "Lakatrazz") != null) {
                LoadModule();
            }
        }

        private static void LoadModule() {
            LabFusion.SDK.Modules.ModuleManager.RegisterModule<PowertoolsModule>();
        }

        public BaseTool[] tools = [
            new FusionTool(),
        ];
    }
}