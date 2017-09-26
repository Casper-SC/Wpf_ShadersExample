using Controls.Shaders;
using System;
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

        private void CustomWindow_Closed(object sender, EventArgs e)
        {
            DeactivateDisabledEffect();
        }

        public static readonly DependencyProperty DisabledEffectProperty = DependencyProperty.Register(
            "DisabledEffect", typeof(Effect), typeof(CustomWindow), new PropertyMetadata(
                new TintShaderEffect() { TintColor = Colors.LightGray },
                new PropertyChangedCallback(EffectPropertiesChanged)));

        public static readonly DependencyProperty UseDisabledEffectInternalProperty = DependencyProperty.Register(
            "UseDisabledEffectInternal", typeof(bool), typeof(CustomWindow), new PropertyMetadata(false,
                new PropertyChangedCallback(EffectPropertiesChanged)));

        private bool UseDisabledEffectInternal
        {
            get { return (bool)GetValue(UseDisabledEffectInternalProperty); }
            set { SetValue(UseDisabledEffectInternalProperty, value); }
        }

        public Effect DisabledEffect
        {
            get { return (Effect)GetValue(DisabledEffectProperty); }
            set { SetValue(DisabledEffectProperty, value); }
        }

        private static void EffectPropertiesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (CustomWindow)d;
            SetEffect(control);
        }

        private static void SetEffect(CustomWindow control)
        {
            if (!control.UseDisabledEffectInternal /*&& !control.UseErrorEffect*/)
            {
                control.Effect = null;
            }
            else if (control.UseDisabledEffectInternal)
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
            if (Owner != null)
            {
                var window = Owner as CustomWindow;
                if (window != null)
                {
                    Closed -= CustomWindow_Closed;
                    Closed += CustomWindow_Closed;
                    window.UseDisabledEffectInternal = true;
                }
            }
        }        

        private void DeactivateDisabledEffect()
        {
            var window = Owner as CustomWindow;
            if (window != null)
            {
                window.UseDisabledEffectInternal = false;
            }
        }
    }
}
