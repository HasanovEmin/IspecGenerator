using Aveva.ApplicationFramework.Presentation;

namespace IspecGenerator
{
    internal class ShowWindow: Command
    {
        private DockedWindow window;

        public ShowWindow(IWindowManager windowManager)
        {
            base.Key = "Emin.IspecGenerator";

            SpecControl ispecController = new SpecControl();
            this.window = windowManager.CreateDockedWindow("IspecGeneratorAddin", "Ispec creator", ispecController, DockedPosition.Right);
            window.Width = 383;
            window.SaveLayout = true;


            window.Closed += _window_Closed;

            windowManager.WindowLayoutLoaded += WindowLayoutLoaded;

            this.ExecuteOnCheckedChange = false;
        }

        private void WindowLayoutLoaded(object sender, System.EventArgs e)
        {
            this.Checked = window.Visible;
        }

        private void _window_Closed(object sender, System.EventArgs e)
        {
            this.Checked = false;
        }

        public override void Execute()
        {
            try
            {
                if (window.Visible)
                {
                    window.Hide();
                }
                else
                    window.Show();

                base.Execute();
            }
            catch (System.Exception)
            {

            }
            
        }
    }
}