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
            if (_expandableColumn >= 0 && _expandableColumn < columnsGridView.Columns.Count)
            {
                Double totalWidth = foldableListView.ActualWidth;
                Double othersWidth = 0;

                foreach (var item in columnsGridView.Columns.Select((v, i) => new { v, i }))
                {
                    if (item.i != _expandableColumn)
                    {
                        othersWidth += item.v.ActualWidth;
                    }
                }

                columnsGridView.Columns[_expandableColumn].Width = totalWidth - othersWidth - columnsGridView.Columns.Count - 8;
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

        public void setItemSource(System.Collections.IEnumerable source)
        {
            foldableListView.ItemsSource = source;
        }
        
        public void addColumn(Binding bind)
        {
            columnsGridView.Columns.Add(new GridViewColumn() { DisplayMemberBinding = bind });
            //columnsGridView.Columns.Add(new GridViewColumn() { DisplayMemberBinding = new Binding() { Path = new PropertyPath("Name") } });
        }

        public void setTitleBinding(Binding bind)
        {
            toggleButton.Content = bind;
        }

        private int _expandableColumn = -1;
        public void setExpandableColumn(int index)
        {
            _expandableColumn = index;
        }
    }
}