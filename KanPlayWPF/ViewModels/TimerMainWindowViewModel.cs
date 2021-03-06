﻿using System;
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

namespace KanPlayWPF.ViewModels
{
    public class TimerMainWindowViewModel : ViewModel
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


        #region expedition2Name変更通知プロパティ
        private string _expedition2Name;

        public string expedition2Name
        {
            get
            { return _expedition2Name; }
            set
            { 
                if (_expedition2Name == value)
                    return;
                _expedition2Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region expedition3Name変更通知プロパティ
        private string _expedition3Name;

        public string expedition3Name
        {
            get
            { return _expedition3Name; }
            set
            { 
                if (_expedition3Name == value)
                    return;
                _expedition3Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region expedition4Name変更通知プロパティ
        private string _expedition4Name;

        public string expedition4Name
        {
            get
            { return _expedition4Name; }
            set
            { 
                if (_expedition4Name == value)
                    return;
                _expedition4Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region repair1NameAndLevel変更通知プロパティ
        private string _repair1NameAndLevel;

        public string repair1NameAndLevel
        {
            get
            { return _repair1NameAndLevel; }
            set
            { 
                if (_repair1NameAndLevel == value)
                    return;
                _repair1NameAndLevel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region repair2NameAndLevel変更通知プロパティ
        private string _repair2NameAndLevel;

        public string repair2NameAndLevel
        {
            get
            { return _repair2NameAndLevel; }
            set
            { 
                if (_repair2NameAndLevel == value)
                    return;
                _repair2NameAndLevel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region repair3NameAndLevel変更通知プロパティ
        private string _repair3NameAndLevel;

        public string repair3NameAndLevel
        {
            get
            { return _repair3NameAndLevel; }
            set
            { 
                if (_repair3NameAndLevel == value)
                    return;
                _repair3NameAndLevel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region repair4NameAndLevel変更通知プロパティ
        private string _repair4NameAndLevel;

        public string repair4NameAndLevel
        {
            get
            { return _repair4NameAndLevel; }
            set
            { 
                if (_repair4NameAndLevel == value)
                    return;
                _repair4NameAndLevel = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region build1TimeProgress変更通知プロパティ
        private string _build1TimeProgress;

        public string build1TimeProgress
        {
            get
            { return _build1TimeProgress; }
            set
            { 
                if (_build1TimeProgress == value)
                    return;
                _build1TimeProgress = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region build2TimeProgress変更通知プロパティ
        private string _build2TimeProgress;

        public string build2TimeProgress
        {
            get
            { return _build2TimeProgress; }
            set
            { 
                if (_build2TimeProgress == value)
                    return;
                _build2TimeProgress = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
