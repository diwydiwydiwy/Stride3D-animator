using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stride.Core.Mathematics;
using Stride.Input;
using Stride.Engine;
using AvaloniaApplicationForStride;

namespace AnimatorExtensionTest
{
    public class Animator : StartupScript
    {
        private bool _showAnimator;
        public bool OpenAnimator { get => _showAnimator; 
                set 
                {
                    AvaloniaProgram.BuildAvaloniaApp().SetupWithoutStarting();
                    new MainWindow().Show();
                }
        }

        public override void Start()
        {
            // Initialization of the script.
        }
    }
}
