using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace Controls.Shaders
{
    public class TintShaderEffect : ShaderEffect
    {
        public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty(
            "Input", typeof(TintShaderEffect), 0);

        public static readonly DependencyProperty TintColorProperty =
            DependencyProperty.Register(
                "TintColor",
                typeof(Color),
                typeof(TintShaderEffect),
                new PropertyMetadata(Color.FromArgb(255, 230, 179, 77), PixelShaderConstantCallback(0)));

        public Brush Input
        {
            get { return ((Brush)(GetValue(InputProperty))); }
            set { SetValue(InputProperty, value); }
        }

        /// <summary>The tint color.</summary>
        public Color TintColor
        {
            get { return ((Color)(this.GetValue(TintColorProperty))); }
            set { SetValue(TintColorProperty, value); }
        }

        public TintShaderEffect()
        {
            string name = AssemblyHelper.GetExecutingAssemblyName();
            Uri uri = new Uri("pack://application:,,,/" + name + ";component/Shaders/TintShaderEffect.ps", UriKind.RelativeOrAbsolute);

            PixelShader pixelShader = new PixelShader();
            pixelShader.UriSource = uri;
            PixelShader = pixelShader;

            UpdateShaderValue(InputProperty);
            UpdateShaderValue(TintColorProperty);
        }
    }
}
