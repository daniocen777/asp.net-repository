namespace WebApiExample.Services
{
    public class UserDataService : IUserDataService
    {
        private List<string> _elements;

        public UserDataService()
        {
            _elements = new List<string>();
            var random = new Random();
            _elements.Add($"Value {random.Next()}");
            _elements.Add($"Value {random.Next()}");
            _elements.Add($"Value {random.Next()}");
            _elements.Add($"Value {random.Next()}");
        }

        public List<string> GetValues()
        {
            return _elements;
        }
    }
}