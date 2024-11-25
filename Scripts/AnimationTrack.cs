using Stride.Animations;
using Stride.Core;
using Stride.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnimatorExtension
{
    [DataContract]
    [ComponentCategory("Animator")]
    public class AnimationTrack
    {
        public AnimationTrack(AnimationComponent animationComponent, string name, AnimationClip clip, AnimationCurve curve)
        {
            AnimationComponent = animationComponent;
            Name = name;
            Clip = clip;
            Curve = curve;
            Enabled = true;
        }
        public AnimationTrack()
        {
            Name = "New animation";
            Clip = new();
            Enabled = true;
        }
        public AnimationComponent AnimationComponent { get; set; }
        public string Name { get; set; }
        public AnimationClip Clip { get; set; }
        public string AnimatedProperty { get; set; }
        public AnimationCurveInterpolationType CurveInterpolationType { get; set; }
        public bool Enabled { get; set; }
        public AnimationCurve Curve { get; set; }
        public void SetAnimatedProperty(string componentName, string propertyPath) =>
            AnimatedProperty = $"[{componentName}].{propertyPath}";

        public static AnimationCurve<T> CreateEmptyCurve<T>(AnimationCurveInterpolationType interpolationType)
        {
            return new AnimationCurve<T>
            {
                InterpolationType = interpolationType
            };
        }
        public static KeyFrameData<T> CreateKeyFrame<T>(float keyTime, T value)
        {
            return new KeyFrameData<T>((CompressedTimeSpan)TimeSpan.FromSeconds(keyTime), value);
        }
    }
}
