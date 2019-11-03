﻿using System.Windows.Forms;

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
                PanelenLabel,CilindersLabel,InzetHorLabel,BazLabel, Laslabel,
                AfmLabel, AwlLabel, GereedLabel, WeekLabel,LocatieLabel,OpmerkingenLabel    
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
