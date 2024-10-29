using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using AvaloniaApplicationForStride;
using System.Reflection;
using System.Diagnostics.Eventing.Reader;
using Stride.Animations;
using Avalonia.Controls;
using Stride.Engine.Design;
using Avalonia.Threading;

namespace AnimatorExtensionTest
{
    public class Animator : StartupScript
    {
        //I'm very sorry for making these guys static
        private static Window _animatorWindow;
        private bool _showAnimator;
        private static bool _firstStart = true;
        private static bool FirstStart { get => _firstStart; set { _firstStart = value; } }
        public bool OpenAnimator 
        { 
            get => _showAnimator; 
            set 
            {
                if (true) return;
                //if (_showAnimator == value) { _showAnimator = value; return; }
                //_showAnimator = value;

                if (FirstStart)
                {
                    AvaloniaProgram.BuildAvaloniaApp().SetupWithoutStarting();
                    FirstStart = false;
                }

                if (_animatorWindow == null)
                {
                    _animatorWindow = new MainWindow();
                    Dispatcher.UIThread.Invoke(() => _animatorWindow.Show());
                    return;
                }
                else
                {
                    Dispatcher.UIThread.Invoke( () => _animatorWindow.Close());
                    _animatorWindow = null;
                    return;
                }
            }
        }

        public override void Start()
        {
            // Initialization of the script.
        }
    }
}
