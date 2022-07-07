namespace WebAPIStudy.Services
{
    public interface IService
    {
        Guid ObtenerScoped();
        Guid ObtenerSingleton();
        Guid ObtenerTransient();
    }

    public class ServiceA : IService
    {
        private readonly ILogger<ServiceA> _logger;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public ServiceA(ILogger<ServiceA> logger, ServiceTransient serviceTransient, 
            ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            _logger = logger;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        public Guid ObtenerTransient() { return serviceTransient.Guid; }
        public Guid ObtenerScoped()    { return serviceScoped.Guid; }
        public Guid ObtenerSingleton() { return serviceSingleton.Guid; }

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

        public Guid ObtenerScoped()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerSingleton()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerTransient()
        {
            throw new NotImplementedException();
        }
    }

    public class ServiceTransient
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceScoped
    {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceSingleton
    {
        public Guid Guid = Guid.NewGuid();
    }



}
