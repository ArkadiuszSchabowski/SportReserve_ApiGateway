namespace SportReserve_ApiGateway.Models.User
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public bool? IsMale { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
