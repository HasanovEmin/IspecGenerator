using Aveva.ApplicationFramework;
using Aveva.ApplicationFramework.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IspecGenerator
{
    public class MainClass : IAddin
    {
        public string Name => "IspecGeneratorAddin";

        public string Description => "Import and export Ispec from and to excel file";

        public void Start(ServiceManager serviceManager)
        {
            IWindowManager windowManager = DependencyResolver.GetImplementationOf<IWindowManager>();
            ICommandManager commandManager = DependencyResolver.GetImplementationOf<ICommandManager>();

            ShowWindow showWindow = new ShowWindow(windowManager);
            commandManager.Commands.Add(showWindow);

        }

        public void Stop()
        {
            
        }
    }
}
