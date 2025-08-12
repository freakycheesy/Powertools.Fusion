using LabFusion.SDK.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowertoolsFusion {
    public class PowertoolsModule : Module {
        public override string Name => "Powertools";

        public override string Author => "freakycheesy";

        public override Version Version => new(1, 0, 0);

        public override ConsoleColor Color => ConsoleColor.Red;

        protected override void OnModuleRegistered() {
            ModuleMessageManager.LoadHandlers(System.Reflection.Assembly.GetExecutingAssembly());
        }

        protected override void OnModuleUnregistered() {
        }
    }
}
