using Banking.Api.Adapters;
using Banking.Api.Models;
using MongoDB.Driver;

namespace Banking.Api.Domain;

public class AccountManager
{
    private readonly MongoAccountsAdapter _adapter;

    public AccountManager(MongoAccountsAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<CollectionResponse<AccountSummaryResponse>> GetAllAccountsAsync()
    {

        var accountsProjection = Builders<AccountEntity>.Projection.Expression(a => new AccountSummaryResponse { Id = a.Id, Name = a.Name });

        var data = await _adapter.Accounts.Find(_ => true).Project(accountsProjection).ToListAsync();
        var response = new CollectionResponse<AccountSummaryResponse>
        {
            Data = data
        };
        return response;
    }

    public async Task<AccountSummaryResponse?> GetAccountByIdAsync(string id)
    {

        var accountsProjection = Builders<AccountEntity>.Projection.Expression(a => new AccountSummaryResponse { Id = a.Id, Name = a.Name });
        var filter = Builders<AccountEntity>.Filter.Where(a => a.Id == id);
        var response = await _adapter.Accounts.Find(filter).Project(accountsProjection).SingleOrDefaultAsync();
        return response;
    }

    public async Task<AccountSummaryResponse> CreateAccountAsync(AccountCreateRequest request)
    {
        var accountEntity = new AccountEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name
        };

        await _adapter.Accounts.InsertOneAsync(accountEntity);

        var response = new AccountSummaryResponse
        {
            Id = accountEntity.Id,
            Name = accountEntity.Name
        };
        return response;

    }
}
