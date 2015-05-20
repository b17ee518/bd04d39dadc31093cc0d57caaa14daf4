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

namespace KanPlayWPF.ViewModels.InfoMainWindow
{
    public class KOverviewTableViewModel : ViewModel
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

        public void Initialize()
        {
        }


        #region kanCount変更通知プロパティ
        private int _kanCount;

        public int kanCount
        {
            get
            { return _kanCount; }
            set
            { 
                if (_kanCount == value)
                    return;
                _kanCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region kanMaxCount変更通知プロパティ
        private int _kanMaxCount;

        public int kanMaxCount
        {
            get
            { return _kanMaxCount; }
            set
            { 
                if (_kanMaxCount == value)
                    return;
                _kanMaxCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        #region slotitemCount変更通知プロパティ
        private int _slotitemCount;

        public int slotitemCount
        {
            get
            { return _slotitemCount; }
            set
            { 
                if (_slotitemCount == value)
                    return;
                _slotitemCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region slotitemMaxCount変更通知プロパティ
        private int _slotitemMaxCount;

        public int slotitemMaxCount
        {
            get
            { return _slotitemMaxCount; }
            set
            { 
                if (_slotitemMaxCount == value)
                    return;
                _slotitemMaxCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region instantRepairCount変更通知プロパティ
        private int _instantRepairCount;

        public int instantRepairCount
        {
            get
            { return _instantRepairCount; }
            set
            { 
                if (_instantRepairCount == value)
                    return;
                _instantRepairCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region instantBuildCount変更通知プロパティ
        private int _instantBuildCount;

        public int instantBuildCount
        {
            get
            { return _instantBuildCount; }
            set
            { 
                if (_instantBuildCount == value)
                    return;
                _instantBuildCount = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region playerLevel変更通知プロパティ
        private int _playerLevel;

        public int playerLevel
        {
            get
            { return _playerLevel; }
            set
            { 
                if (_playerLevel == value)
                    return;
                _playerLevel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region playerExpNext変更通知プロパティ
        private int _playerExpNext;

        public int playerExpNext
        {
            get
            { return _playerExpNext; }
            set
            { 
                if (_playerExpNext == value)
                    return;
                _playerExpNext = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region furnitureCoin変更通知プロパティ
        private int _furnitureCoin;

        public int furnitureCoin
        {
            get
            { return _furnitureCoin; }
            set
            { 
                if (_furnitureCoin == value)
                    return;
                _furnitureCoin = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
