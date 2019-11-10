using System.Reflection;
using System.Text;

namespace LoadingAssemblies.Extension
{
    public class Information
    {
        public string GetAssembliesInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"LoadingAssemblies.Extension Executing Assembly: {Assembly.GetExecutingAssembly()}");
            sb.AppendLine($"LoadingAssemblies.Extension Calling Assembly: {Assembly.GetCallingAssembly()}");
            sb.AppendLine($"LoadingAssemblies.Extension Entry Assembly: {Assembly.GetEntryAssembly()}");

            return sb.ToString();
        }
    }
}
