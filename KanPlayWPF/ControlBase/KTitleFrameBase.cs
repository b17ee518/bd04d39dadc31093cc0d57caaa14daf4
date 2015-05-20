using KanPlayWPF.Views;
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
    public class KTitleFrame : UserControl
    {
        public KTitleFrame()
        {
            this.MouseLeftButtonDown += onMouseLeftButtonDown;
            this.MouseLeftButtonUp += onMouseLeftButtonUp;
            this.MouseMove += onMouseMove;
        }

        private bool _bMouseDown = false;
        private System.Drawing.Point _lastMousePos = new System.Drawing.Point();

        protected void onMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _bMouseDown = true;
            _lastMousePos = System.Windows.Forms.Control.MousePosition;
            this.CaptureMouse();
        }

        private void moveAllSubWindows(Double x, Double y)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (!(window is MainWindow))
                {
                    window.Left += x;
                    window.Top += y;
                }
            }
        }

        protected void onMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _bMouseDown = false;
            this.ReleaseMouseCapture();

            Window parentWindow = Window.GetWindow(this);
            bool isMainWindow = parentWindow is MainWindow;
            Double margin = 20;
            if (parentWindow.Left < margin)
            {
                if (isMainWindow)
                {
                    moveAllSubWindows(-parentWindow.Left, 0);
                }
                parentWindow.Left = 0;
            }
            if (parentWindow.Top < margin)
            {
                if (isMainWindow)
                {
                    moveAllSubWindows(0, -parentWindow.Top);
                }
                parentWindow.Top = 0;
            }
            if (!isMainWindow)
            {
                MainWindow mainWindow = MainWindow.getMainWindow();
                Double mainWindowBottom = mainWindow.Top + mainWindow.ActualHeight;
                if (Math.Abs(parentWindow.Top - mainWindowBottom) < margin)
                {
                    parentWindow.Top = mainWindowBottom;
                }
            }
        }

        protected void onMouseMove(object sender, MouseEventArgs e)
        {
            if (_bMouseDown)
            {
                Window parentWindow = Window.GetWindow(this);

                System.Drawing.Point curPos = System.Windows.Forms.Control.MousePosition;
                Double moveX = (curPos.X - _lastMousePos.X);
                Double moveY = (curPos.Y - _lastMousePos.Y);

                if (parentWindow is MainWindow)
                {
                    moveAllSubWindows(moveX, moveY);
                }

                parentWindow.Left += moveX;
                parentWindow.Top += moveY;
                _lastMousePos = curPos;
            }
        }
    }
}
