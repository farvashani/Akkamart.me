namespace Akkamart.Home.Shared.Models {
    public class RegisterService {
        public RegisterService (ServiceRegistery registery) {
            this.Registery = registery;

        }
        public ServiceRegistery Registery { get; set; }
    }
}