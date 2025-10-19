namespace ProfileAPI.DTOs
{
    public class ProfileDto
    {
        public string Status { get; set; }
        public UserDto User { get; set; }
        public string Timestamp { get; set; }
        public string Fact { get; set; }
    }

}
