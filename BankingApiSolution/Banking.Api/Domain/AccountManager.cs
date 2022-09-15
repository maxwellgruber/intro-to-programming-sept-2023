using Banking.Api.Models;

namespace Banking.Api.Domain;

public class AccountManager
{
    public async Task<CollectionResponse<AccountSummaryResponse>> GetAllAccountsAsync()
    {
        var response = new CollectionResponse<AccountSummaryResponse>
        {
            Data = new List<AccountSummaryResponse>
            {

               new AccountSummaryResponse { Id = "1", Name = "Bob Smith"},
               new AccountSummaryResponse { Id = "2", Name = "Jill Jones"}
            }
        };
        return response;
    }

    public async Task<AccountSummaryResponse?> GetAccountByIdAsync(string id)
    {
        var response = new AccountSummaryResponse { Id = id, Name = "Bob Smith" };
        return response;
    }

    public async Task<AccountSummaryResponse> CreateAccountAsync(AccountCreateRequest request)
    {
        var response = new AccountSummaryResponse
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name
        };
        return response;
    }
}
