using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using KanPlayWPF.ControlBase;
using System.Windows.Threading;

namespace KanPlayWPF.Views.KFoldableListView
{
    /* 
     * ViewModelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedWeakEventListenerや
     * CollectionChangedWeakEventListenerを使うと便利です。独自イベントの場合はLivetWeakEventListenerが使用できます。
     * クローズ時などに、LivetCompositeDisposableに格納した各種イベントリスナをDisposeする事でイベントハンドラの開放が容易に行えます。
     *
     * WeakEventListenerなので明示的に開放せずともメモリリークは起こしませんが、できる限り明示的に開放するようにしましょう。
     */

    /// <summary>
    /// FoldableListView.xaml の相互作用ロジック
    /// </summary>
    public partial class KFoldableListView : KFoldableListViewBase
    {
        public KFoldableListView()
        {
            InitializeComponent();
            toggleButton.IsChecked = true;

            foldableListView.SizeChanged += foldableListView_SizeChanged;
            /*
             * List<User> items = new List<User>();
             * items.Add(new User() { Name = "John Doe", Age = 42 });
             * items.Add(new User() { Name = "Jane Doe", Age = 39 });
             * items.Add(new User() { Name = "Sammy Doe", Age = 13 });
             * foldableListView.ItemsSource = items;
             * 
             * columnsGridView.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding() { Path = new PropertyPath("Name") } });
             * columnsGridView.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding() { Path = new PropertyPath("Age") } });
             */
        }

        void foldableListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            GridView gv = foldableListView.View as GridView;
            if (_expandableColumn >= 0 && _expandableColumn < gv.Columns.Count)
            {
                Double totalWidth = foldableListView.ActualWidth;
                Double othersWidth = 0;

                foreach (var item in gv.Columns.Select((v, i) => new { v, i }))
                {
                    if (item.i != _expandableColumn)
                    {
                        othersWidth += item.v.ActualWidth;
                    }
                }

                Double adjustWidth = totalWidth - othersWidth - gv.Columns.Count - 8;
                if (gv.Columns[_expandableColumn].ActualWidth < adjustWidth)
                {
                    gv.Columns[_expandableColumn].Width = adjustWidth;
                }
            }
            (sender as DispatcherTimer).Stop();
        }

        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        protected override void collapseListView()
        {
            foldableListView.Visibility = Visibility.Collapsed;
        }
        protected override void expandListView()
        {
            foldableListView.Visibility = Visibility.Visible;
        }

        public void applyTableStyle(string resourceName)
        {
            foldableListView.Style = (Application.Current.FindResource(resourceName) as Style);
        }

        public void setItemSource(System.Collections.IEnumerable source)
        {
            foldableListView.ItemsSource = source;
        }

        public void setTitleBinding(BindingBase bind)
        {
            toggleButton.Content = bind;
        }

        public void setTitleBinding(BindingBase contentBind, BindingBase foregroundBind, BindingBase backgroundBind)
        {
            toggleButton.Content = contentBind;
            BindingOperations.SetBinding(toggleButton.Foreground, SolidColorBrush.ColorProperty, foregroundBind);
            BindingOperations.SetBinding(toggleButton.Background, SolidColorBrush.ColorProperty, backgroundBind);
        }

        private int _expandableColumn = -1;
        public void setExpandableColumn(int index)
        {
            _expandableColumn = index;
        }

        public void setFold(bool bFold)
        {
            toggleButton.IsChecked = !bFold;
        }

        #region eliminateMargin
        private void ListViewItem_Loaded(object sender, RoutedEventArgs e)
        {
            ListViewItem lvi = sender as ListViewItem;
            GridViewRowPresenter gvrp = FindVisualChild<GridViewRowPresenter>(lvi);
            IEnumerable<ContentPresenter> cps = FindVisualChildren<ContentPresenter>(gvrp);
            foreach (var cp in cps)
            {
                cp.Margin = new Thickness(0);
            }
        }

        private T FindVisualChild<T>(Visual visual) where T : Visual
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child != null)
                {
                    T correctlyTyped = child as T;
                    if (correctlyTyped != null)
                    {
                        return correctlyTyped;
                    }

                    T descendent = FindVisualChild<T>(child);
                    if (descendent != null)
                    {
                        return descendent;
                    }
                }
            }

            return null;
        }


        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        #endregion

    }
}