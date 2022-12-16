namespace ValidationTest.Services
{
    public class LocatorData
    {
        public string Locator { get; set; }
        [ValidateNotEmpty]
        public string Name { get; set; }
        [ValidateMaximumLength(20)]
        public string Value { get; set; }
    }

    public class Locator : IReturn<string>
    {
        [ValidateNotEmpty]
        public string Site { get; set; }        
        public List<LocatorData> Parameters { get; set; } // **** here's the example
    }

    public class ActivityToUnit4DTO
    {
        [ValidateNotEmpty]
        public int ActivityId { get; set; }
        [ValidateNotEmpty]
        public string ActivityDescription { get; set; }       
        [ValidateNotEmpty]
        public double TimeInvoiced { get; set; }
        [ValidateNotEmpty]
        public double TimeSpent { get; set; }
    }
    public class UserActivityToUnit4 : IReturn<string>
    {
        [ValidateNotEmpty]
        public List<ActivityToUnit4DTO> ActivitiesToUnit4 { get; set; }
    }

    public class UserActivityToUnit4IEnumerableChildren : IReturn<string>
    {
        [ValidateNotEmpty]
        public IEnumerable<ActivityToUnit4DTO> ActivitiesToUnit4 { get; set; }
    }
  

    public class TestService : Service
    {
        public object Post(Locator request)
        {
            return "OK";
        }

        public string Post(UserActivityToUnit4 request)
        {
            return "OK";
        }

        public string Post(UserActivityToUnit4IEnumerableChildren request)
        {
            return "OK";
        }
    }
}
