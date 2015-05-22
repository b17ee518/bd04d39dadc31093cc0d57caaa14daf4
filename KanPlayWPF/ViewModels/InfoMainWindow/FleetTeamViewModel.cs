using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using KanPlayWPF.Models;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace KanPlayWPF.ViewModels.InfoMainWindow
{
    public class FleetTeamViewModel : ViewModel
    {
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */


        public FleetTeamViewModel()
        {
            shipsViewModel = new List<FleetTableViewModel>();
            Initialize();
        }

        public List<FleetTableViewModel> shipsViewModel { get; set; }
        public void Initialize()
        {
            fleetName = "";
            level = -1;
            seiku = -1;
            sakuteki = -1;
            sakutekiCalced = -1;

            this.PropertyChanged += FleetTeamViewModel_PropertyChanged;
        }

        void FleetTeamViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "fleetTeamState")
            {
                titleColorBrush = FleetTeamModel.getFleetTeamColorBrushFromState(this.fleetTeamState);
            }
        }

        public void AddVM(FleetTableViewModel vm)
        {
            shipsViewModel.Add(vm);
        }

        #region fleetName変更通知プロパティ
        private string _fleetName;

        public string fleetName
        {
            get
            { return _fleetName; }
            set
            { 
                if (_fleetName == value)
                    return;
                _fleetName = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region level変更通知プロパティ
        private int _level;

        public int level
        {
            get
            { return _level; }
            set
            { 
                if (_level == value)
                    return;
                _level = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region seiku変更通知プロパティ
        private int _seiku;

        public int seiku
        {
            get
            { return _seiku; }
            set
            { 
                if (_seiku == value)
                    return;
                _seiku = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region sakuteki変更通知プロパティ
        private int _sakuteki;

        public int sakuteki
        {
            get
            { return _sakuteki; }
            set
            { 
                if (_sakuteki == value)
                    return;
                _sakuteki = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region sakutekiCalced変更通知プロパティ
        private int _sakutekiCalced;

        public int sakutekiCalced
        {
            get
            { return _sakutekiCalced; }
            set
            { 
                if (_sakutekiCalced == value)
                    return;
                _sakutekiCalced = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region fleetTeamState変更通知プロパティ
        private FleetTeamState _fleetTeamState;

        public FleetTeamState fleetTeamState
        {
            get
            { return _fleetTeamState; }
            set
            { 
                if (_fleetTeamState == value)
                    return;
                _fleetTeamState = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        /////

        #region titleColorBrush変更通知プロパティ
        private SolidColorBrush _titleColorBrush;

        public SolidColorBrush titleColorBrush
        {
            get
            { return _titleColorBrush; }
            set
            { 
                if (_titleColorBrush == value)
                    return;
                _titleColorBrush = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
