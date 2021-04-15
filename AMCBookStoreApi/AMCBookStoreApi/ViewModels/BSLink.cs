using WebApi.Hal;

namespace AMCBookStoreApi.ViewModels
{
    public class BSLink : Link
    {
        public string Method { get; set; } = "GET";
    }
}
