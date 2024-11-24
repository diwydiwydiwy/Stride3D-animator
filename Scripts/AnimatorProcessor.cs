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

namespace AnimatorExtension
{
    public class AnimatorProcessor : EntityProcessor<AnimatorComponent>
    {
        private Logger _logger;
        private Logger Log
        {
            get
            {
                if (_logger != null)
                {
                    return _logger;
                }

                var className = GetType().FullName;
                _logger = GlobalLogger.GetLogger(className);
                return _logger;
            }
        }
        private InputManager Input { get; set; }
        private static bool FirstStart { get; set; } = false;
        public AnimatorProcessor(): base(typeof(AnimatorComponent)){ }
        protected override void OnSystemAdd() 
        {
            Input = Services.GetSafeServiceAs<InputManager>();
        }
  
        public override void Update(GameTime time)
        {
            foreach (var component in ComponentDatas.Values)
            {
                if (!FirstStart) 
                {
                    component.Log = Log;
                    component.InitializeAnimator();
                    FirstStart = true;
                }
                if (Input.IsKeyDown(Keys.LeftShift))
                {
                    if (Input.IsKeyPressed(Keys.F1))
                    {
                        component.OpenAnimator();
                    }
                }
            }
        }
    }
}
