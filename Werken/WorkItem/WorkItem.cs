using System.ComponentModel;

namespace Werken
{
    public class WorkItem : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string OrderNr { get; set; }
        private string productionNr;
        public string ProductionNr { get { return productionNr; } set { if (productionNr != value) { productionNr = value; Notify("ProductionNr"); } } }

        public string Project { get; set; }
        public string Customer { get; set; }

        public int Chalets { get; set; }
        public int Kozijnen { get; set; }
        public int Ramen { get; set; }
        public int Deuren { get; set; }
        public int LosseOnderdelen { get; set; }


        private string glas;
        public string Glas { get { return glas; } set { if (glas != value) { glas = value; Notify("Glas"); } } }

        private string roosters;
        public string Roosters { get { return roosters; } set { if (roosters != value) { roosters = value; Notify("Roosters"); } } }

        private string profielem;
        public string Profielen { get { return profielem; } set { if (profielem != value) { profielem = value; Notify("Profielen"); } } }

        private string panelen;
        public string Panelen { get { return panelen; } set { if (panelen != value) { panelen = value; Notify("Panelen"); } } }


        private string cilinders;
        public string Cilinders { get { return cilinders; } set { if (cilinders != value) { cilinders = value; Notify("Cilinders"); } } }

        private string inzethor;
        public string Inzethor { get { return inzethor; } set { if (inzethor != value) { inzethor = value; Notify("Inzethor"); } } }

        private string inkoopKozijnen;
        public string InkoopKozijnen { get { return inkoopKozijnen; } set { if (inkoopKozijnen != value) { inkoopKozijnen = value; Notify("InkoopKozijnen"); } } }

        private string inkoopDTSDorpels;
        public string InkoopDTSDorpels { get { return inkoopDTSDorpels; } set { if (inkoopDTSDorpels != value) { inkoopDTSDorpels = value; Notify("InkoopDTSDorpels"); } } }


        private string baz;
        public string BAZ { get { return baz; } set { if (baz != value) { baz = value; Notify("BAZ"); } } }

        private string las;
        public string LAS { get { return las; } set { if (las != value) { las = value; Notify("LAS"); } } }

        private string afm1;
        public string AFM1 { get { return afm1; } set { if (afm1 != value) { afm1 = value; Notify("AFM1"); } } }

        private string afm1a;
        public string AFM1A { get { return afm1a; } set { if (afm1a != value) { afm1a = value; Notify("AFM1A"); } } }

        private string afm2;
        public string AFM2 { get { return afm2; } set { if (afm2 != value) { afm2 = value; Notify("AFM2"); } } }

        private string afm3;
        public string AFM3 { get { return afm3; } set { if (afm3 != value) { afm3 = value; Notify("AFM3"); } } }


        private string awl;
        public string AWL { get { return awl; } set { if (awl != value) { awl = value; Notify("AWL"); } } }

        private string complete;
        public string Complete { get { return complete; } set { if (complete != value) { complete = value; Notify("Complete"); } } }

        private string leverWeek;
        public string LeverWeek { get { return leverWeek; } set { if (leverWeek != value) { leverWeek = value; Notify("LeverWeek"); } } }

        private string locatie;
        public string Locatie { get { return locatie; } set { if (locatie != value) { locatie = value; Notify("Locatie"); } } }

        private string remarks;
        public string Remarks { get { return remarks; } set { if (remarks != value) { remarks = value; Notify("Remarks"); } } }

        private int glasColor;
        public int GlasColor { get { return glasColor; } set { if (glasColor != value) { glasColor = value; Notify("GlasColor"); } } }

        private int roostersColor;
        public int RoostersColor { get { return roostersColor; } set { if (roostersColor != value) { roostersColor = value; Notify("RoostersColor"); } } }

        private int cilindersColor;
        public int CilindersColor { get { return cilindersColor; } set { if (cilindersColor != value) { cilindersColor = value; Notify("CilindersColor"); } } }

        private int inzethorColor;
        public int InzethorColor { get { return inzethorColor; } set { if (inzethorColor != value) { inzethorColor = value; Notify("InzethorColor"); } } }

        private int inkoopKozijnenColor;
        public int InkoopKozijnenColor { get { return inkoopKozijnenColor; } set { if (inkoopKozijnenColor != value) { inkoopKozijnenColor = value; Notify("InkoopKozijnenColor"); } } }

        private int inkoopDTSDorpelsColor;
        public int InkoopDTSDorpelsColor { get { return inkoopDTSDorpelsColor; } set { if (inkoopDTSDorpelsColor != value) { inkoopDTSDorpelsColor = value; Notify("InkoopDTSDorpelsColor"); } } }

        private int remarksColor;
        public int RemarksColor { get { return remarksColor; } set { if (remarksColor != value) { remarksColor = value; Notify("RemarksColor"); } } }

        private int profielenColor;
        public int ProfielenColor { get { return profielenColor; } set { if (profielenColor != value) { profielenColor = value; Notify("ProfielenColor"); } } }

        private int panelenColor;
        public int PanelenColor { get { return panelenColor; } set { if (panelenColor != value) { panelenColor = value; Notify("PanelenColor"); } } }

        public decimal Uren { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public static class WorkItemUtils
    {
        public static bool IsEmptyRow(this WorkItem item)
        {
            return string.IsNullOrEmpty(item.OrderNr) &&
                string.IsNullOrEmpty(item.ProductionNr) &&
                string.IsNullOrEmpty(item.Customer);
        }

        public static bool IsRemarkRow(this WorkItem item)
        {
            return item.IsEmptyRow() &&
                !string.IsNullOrEmpty(item.Project);
        }
    }
}
