using Controls.Shaders;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Controls
{
    public class CustomWindow : Window
    {
        public CustomWindow()
        {
            Loaded += CustomWindow_Loaded;
        }

        private void CustomWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ActivateDisabledEffect();
        }

        private void CustomWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DeactivateDisabledEffect();
        }

        public static readonly DependencyProperty DisabledEffectProperty = DependencyProperty.Register(
            "DisabledEffect", typeof(Effect), typeof(CustomWindow), new PropertyMetadata(
                new TintShaderEffect() { TintColor = Colors.LightGray },
                new PropertyChangedCallback(EffectPropertiesChanged)));

        public static readonly DependencyProperty UseDisabledEffectProperty = DependencyProperty.Register(
            "UseDisabledEffect", typeof(bool), typeof(CustomWindow), new PropertyMetadata(false,
                new PropertyChangedCallback(EffectPropertiesChanged)));

        public bool UseDisabledEffect
        {
            get { return (bool)GetValue(UseDisabledEffectProperty); }
            set { SetValue(UseDisabledEffectProperty, value); }
        }

        public Effect DisabledEffect
        {
            get { return (Effect)GetValue(DisabledEffectProperty); }
            set { SetValue(DisabledEffectProperty, value); }
        }

        private static void EffectPropertiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CustomWindow)d;
            SetEffectToControl(control);
        }

        private static void SetEffectToControl(CustomWindow control)
        {
            if (!control.UseDisabledEffect /*&& !control.UseErrorEffect*/)
            {
                control.Effect = null;
            }
            else if (control.UseDisabledEffect)
            {
                control.Effect = control.DisabledEffect;
            }
            //else if (control.UseErrorEffect)
            //{
            //    control.Effect = control.ErrorEffect;
            //}
        }

        private void ActivateDisabledEffect()
        {
            Closing += CustomWindow_Closing;
            if (Owner != null)
            {
                var window = Owner as CustomWindow;
                if (window != null)
                {
                    window.UseDisabledEffect = true;
                }
            }
        }

        private void DeactivateDisabledEffect()
        {
            var window = Owner as CustomWindow;
            if (window != null)
            {
                window.UseDisabledEffect = false;
            }
        }
    }
}
