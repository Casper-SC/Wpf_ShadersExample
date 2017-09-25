using System.Reflection;

namespace Controls
{
    public static class AssemblyHelper
    {
        public static string GetExecutingAssemblyName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
