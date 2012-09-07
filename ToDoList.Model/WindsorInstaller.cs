using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoList.Model
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ITaskListRepository>().ImplementedBy<MemoryTaskList>().LifestyleTransient(),
                Component.For<ITaskListRepository>().ImplementedBy<SqlTaskList>().LifestyleTransient().IsDefault(),
                Component.For<ITaskListRepository>().ImplementedBy<EdmTaskList>().LifestyleTransient(),
                Component.For<ITaskListRepository>().ImplementedBy<EdmWithSprocsTaskList>().LifestyleTransient()
                );
        }
    }
}
