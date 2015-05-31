using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using KanPlayWPF.ViewModels.InfoMainWindow;
using System.Collections.ObjectModel;

namespace KanPlayWPF.Views.InfoMainWindowControls
{
    /// <summary>
    /// Interaction logic for KOverviewTable.xaml
    /// </summary>
    public partial class KOverviewTable : UserControl
    {
        public KOverviewTableViewModel overviewTableVM {get; set;}

        private int _minLeftColumnWidth = 175;

        public KOverviewTable()
        {
            InitializeComponent();
            overviewTableVM = new KOverviewTableViewModel();
            overviewTableListView.Items.Add(overviewTableVM);

            ((System.ComponentModel.INotifyPropertyChanged)gridViewColumn0).PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "ActualWidth")
                {
                    if (gridViewColumn0.ActualWidth < _minLeftColumnWidth)
                    {
                        gridViewColumn0.Width = _minLeftColumnWidth;
                        gridViewColumn1.Width = overviewTableListView.ActualWidth - _minLeftColumnWidth - 8;
                    }
                }
            };
        }
    }
}
