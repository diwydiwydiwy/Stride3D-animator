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
using Stride.Games;
using Stride.Core;
using Stride.Rendering;
using Stride.Core.Diagnostics;
using System.ComponentModel;

namespace AnimatorExtension
{
    [DataContract(nameof(AnimatorComponent))]
    [ComponentCategory("Animator")]
    [DefaultEntityComponentProcessor(typeof(AnimatorProcessor), ExecutionMode = ExecutionMode.Editor)]
    public class AnimatorComponent: EntityComponent
    {
        private Window _animatorWindow;
        public List<ProceduralAnimation> Animations = [];
        [DataMemberIgnore] public Logger Log { get; set; }

        public void InitializeAnimator() 
        {
            try
            {
                AvaloniaProgram.BuildAvaloniaApp().SetupWithoutStarting();
            }
            catch (Exception e)
            {
                Log.Error($"Avalonia builder has stopped with an exception thrown: {e}");
            }
            finally 
            {
                _animatorWindow = new MainWindow();
            }
        }

        public void OpenAnimator()
        {
            Log.Debug("Try opening");
            if (!_animatorWindow.IsVisible)
            {
                Dispatcher.UIThread.Invoke(() => _animatorWindow.Show());
                return;
            }
        }
    }
}
