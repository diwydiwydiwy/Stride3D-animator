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

namespace AnimatorExtensionTest
{
    public class Animator : StartupScript
    {
        private Window _animatorWindow;
        private bool _showAnimator;
        private bool _firstStart;
        private bool FirstStart { get => _firstStart; set { _firstStart = value; } }
        public bool OpenAnimator 
        { 
            get => _showAnimator; 
            set 
            {
                AvaloniaProgram.BuildAvaloniaApp().SetupWithoutStarting();
                FirstStart = false;
                if (_animatorWindow != null) 
                { 
                    _animatorWindow.Close(); 
                    _animatorWindow = null;
                    return; 
                }
                _animatorWindow = new MainWindow();
                _animatorWindow.Show();
            }
        }

        public override void Start()
        {
            // Initialization of the script.
        }
    }
}
