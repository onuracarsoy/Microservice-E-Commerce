namespace Shop.ServiceDistribute.Model
{
	public class JwtResponseModel
	{
        public string Token { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}
