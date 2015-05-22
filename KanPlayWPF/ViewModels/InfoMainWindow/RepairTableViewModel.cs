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
using System.Windows.Media;

namespace KanPlayWPF.ViewModels.InfoMainWindow
{
    public class RepairTableViewModel : ViewModel
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

        public RepairTableViewModel()
        {
            Initialize();
        }
        public void Initialize()
        {
            shipName = "-";
            level = -1;
            cond = -1;
            nowHp = -1;
            maxHp = -1;
            repairTime = -1;

            this.PropertyChanged += RepairTableViewModel_PropertyChanged;
//             hpColorBrush = BrushModel.getWhiteColorBrush();
//             kanColorBrush = BrushModel.getWhiteColorBrush();
        }

        void RepairTableViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "cond")
            {
                condState = CondModel.getCondStateFromCond(this.cond);
            }
            else if (e.PropertyName == "condState")
            {
                kanColorBrush = CondModel.getCondColorBrushFromCondState(condState);
            }
            else if (e.PropertyName == "nowHp" || e.PropertyName == "maxHp")
            {
                woundState = WoundModel.getWoundStateFromHP(this.nowHp, this.maxHp);
            }
            else if (e.PropertyName == "woundState")
            {
                hpColorBrush = WoundModel.getWoundColorBrushFromWoundState(this.woundState);
                stateString = WoundModel.getStateStringFromWoundState(this.woundState);
            }
            else if (e.PropertyName == "repairTime")
            {
                repairTimeString = TimeStringConvertModel.convertMSToString(repairTime);
            }
        }
        
        #region shipName変更通知プロパティ
        private string _shipName;

        public string shipName
        {
            get
            { return _shipName; }
            set
            { 
                if (_shipName == value)
                    return;
                _shipName = value;
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

        #region cond変更通知プロパティ
        private int _cond;

        public int cond
        {
            get
            { return _cond; }
            set
            { 
                if (_cond == value)
                    return;
                _cond = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region repairTime変更通知プロパティ
        private Int64 _repairTime;

        public Int64 repairTime
        {
            get
            { return _repairTime; }
            set
            { 
                if (_repairTime == value)
                    return;
                _repairTime = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region nowHp変更通知プロパティ
        private int _nowHp;

        public int nowHp
        {
            get
            { return _nowHp; }
            set
            { 
                if (_nowHp == value)
                    return;
                _nowHp = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region maxHp変更通知プロパティ
        private int _maxHp;

        public int maxHp
        {
            get
            { return _maxHp; }
            set
            { 
                if (_maxHp == value)
                    return;
                _maxHp = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        ////
        
        #region woundState変更通知プロパティ
        private WoundState _woundState;

        public WoundState woundState
        {
            get
            { return _woundState; }
            set
            {
                if (_woundState == value)
                    return;
                _woundState = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region condState変更通知プロパティ
        private CondState _condState;

        public CondState condState
        {
            get
            { return _condState; }
            set
            {
                if (_condState == value)
                    return;
                _condState = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region stateString変更通知プロパティ
        private string _stateString;

        public string stateString
        {
            get
            { return _stateString; }
            set
            {
                if (_stateString == value)
                    return;
                _stateString = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region hpColorBrush変更通知プロパティ
        private SolidColorBrush _hpColorBrush;

        public SolidColorBrush hpColorBrush
        {
            get
            { return _hpColorBrush; }
            set
            {
                if (_hpColorBrush == value)
                    return;
                _hpColorBrush = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region kanColorBrush変更通知プロパティ
        private SolidColorBrush _kanColorBrush;

        public SolidColorBrush kanColorBrush
        {
            get
            { return _kanColorBrush; }
            set
            {
                if (_kanColorBrush == value)
                    return;
                _kanColorBrush = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region repairTimeString変更通知プロパティ
        private string _repairTimeString;

        public string repairTimeString
        {
            get
            { return _repairTimeString; }
            set
            {
                if (_repairTimeString == value)
                    return;
                _repairTimeString = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
