using System.Windows.Forms;

namespace Werken.Controls
{
    public partial class WorkItemHdrCtrl : UserControl
    {
        public WorkItemHdrCtrl()
        {
            InitializeComponent();
            LayoutControls();
        }

        private void LayoutControls()
        {
            Control[] labels =
            {
                /*OrderNrLabel,*/ProductionNrLabel,ProjectLabel,OpdrachtGeverLabel,ChaletsLabel,KozijnenLabel,
                RamenLabel,DeurenLabel, OnderdelenLabel,GlasLabel,RoostersLabel,ProfielenLabel,
                PanelenLabel,CilindersLabel,InzetHorLabel,InkoopKozijnenLabel,inkoopDTSDorpelsLabel,
                BazLabel, Laslabel, Afm1Label, Afm1ALabel, Afm2Label, Afm3Label, AwlLabel,
                GereedLabel, WeekLabel,LocatieLabel/*,OpmerkingenLabel,UrelLabel*/    
            };

            int x = OrderNrLabel.Left + OrderNrLabel.Width;
            foreach( var label in labels )
            {
                label.Left = x;
                x += label.Width - 2;
            }
        }
    }
}
