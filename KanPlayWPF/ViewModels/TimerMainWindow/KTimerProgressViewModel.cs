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

namespace KanPlayWPF.ViewModels.TimerMainWindow
{
    public class KTimerProgressViewModel : ViewModel
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

        public KTimerProgressViewModel()
        {
            Initialize();
        }
        public void Initialize()
        {
            progressBarValue = 0;
            progressBarColor = BrushModel.getProgressBarColorStaticResource(ProgressBarState.Empty);
        }

        #region leftString変更通知プロパティ
        private string _leftString;

        public string leftString
        {
            get
            { return _leftString; }
            set
            { 
                if (_leftString == value)
                    return;
                _leftString = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region rightString変更通知プロパティ
        private string _rightString;

        public string rightString
        {
            get
            { return _rightString; }
            set
            { 
                if (_rightString == value)
                    return;
                _rightString = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        #region progressBarValue変更通知プロパティ
        private int _progressBarValue;

        public int progressBarValue
        {
            get
            { return _progressBarValue; }
            set
            { 
                if (_progressBarValue == value)
                    return;
                _progressBarValue = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        
        #region progressBarColor変更通知プロパティ
        private SolidColorBrush _progressBarColor;

        public SolidColorBrush progressBarColor
        {
            get
            { return _progressBarColor; }
            set
            { 
                if (_progressBarColor == value)
                    return;
                _progressBarColor = value;
                RaisePropertyChanged();
            }
        }
        #endregion

    }
}
