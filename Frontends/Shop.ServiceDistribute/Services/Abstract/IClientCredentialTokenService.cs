namespace Shop.ServiceDistribute.Services.Abstract
{
	public interface IClientCredentialTokenService
	{

		Task<string> GetToken();
	}
}
