using Autofac;
using clby_ufop.Core.Func;

namespace clby_ufop_ImageSharp.Funcs
{
    public class FuncModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var ts = this.ThisAssembly.GetTypes();
            foreach (var t in ts)
            {
                if (typeof(IFunc).IsAssignableFrom(t) && t.IsPublic)
                {
                    builder.RegisterType(t).As<IFunc>().Named<IFunc>(t.Name).SingleInstance();
                }
            }
        }
    }
}
