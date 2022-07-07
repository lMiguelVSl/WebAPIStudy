namespace WebAPIStudy.Services
{
    public interface IService
    {
    }

    public class ServiceA : IService
    {
        private readonly ILogger<ServiceA> _logger;

        public ServiceA(ILogger<ServiceA> logger)
        {
            _logger = logger;
        }

        public void DoTask()
        {

        }
    }
    public class ServiceB : IService
    {
        private readonly ILogger<ServiceB> _logger;

        public ServiceB(ILogger<ServiceB> logger)
        {
            _logger = logger;
        }

        public void DoTaskB()
        {

        }

    }

    public class ServiceTransient
    {

    }

    public class ServiceScoped
    {

    }

    public class ServiceSingleton
    {

    }



}
