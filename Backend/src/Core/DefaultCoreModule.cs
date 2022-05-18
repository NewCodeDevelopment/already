using Autofac;
namespace Core;

public class DefaultCoreModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // builder.RegisterType<AgreementModificationService>()
        //     .As<AgreementModificationService>().InstancePerLifetimeScope();
        //
        // builder.RegisterType<ProjectModificationService>()
        //     .As<ProjectModificationService>().InstancePerLifetimeScope();
    }
}
