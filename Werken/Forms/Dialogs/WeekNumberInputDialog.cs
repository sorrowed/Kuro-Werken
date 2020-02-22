using System;
using System.Windows.Forms;
using Werken.Support;

namespace Werken.Forms.Dialogs
{
    public partial class WeekNumberInputDialog : Form
    {
        private Week _week;

        public Week Week
        {
            get { return _week; }
            set
            {
                _week = value;
                calendar.SetDate(_week.Get( DateTime.Today.DayOfWeek));
            }
        }


        public WeekNumberInputDialog()
        {
            InitializeComponent();
        }

        private void calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            _week = new Week(calendar.SelectionStart);
            DialogResult = DialogResult.OK;
        }
    }
}
