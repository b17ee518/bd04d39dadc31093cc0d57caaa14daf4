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

namespace KanPlayWPF.ControlBase
{
    public abstract class KFoldableListViewBase : UserControl
    {
        public KFoldableListViewBase()
        {
        }
        protected void onToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            expandListView();
        }

        protected void onToggleButtonUnchecked(object sender, RoutedEventArgs e)
        {
            collapseListView();
        }

        protected abstract void collapseListView();
        protected abstract void expandListView();
    }
}
