using MongoDB.Driver;
using RebarProject3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebarProject3.DataAccess
{
    public class AccountDataAccess
    {
        private IMongoCollection<Account> accountsCollection;

        public AccountDataAccess(IMongoDatabase database)
        {
            accountsCollection = database.GetCollection<Account>("Accounts");
        }

        public async Task<List<Account>> GetAllAccounts()
        {
            var result = await accountsCollection.FindAsync(_ => true);
            return await result.ToListAsync();
        }

        public async Task CreateAccount(Account account)
        {
            await accountsCollection.InsertOneAsync(account);
        }

        public async Task UpdateAccount(Account account)
        {
            var filter = Builders<Account>.Filter.Eq(x => x.Id, account.Id);
            await accountsCollection.ReplaceOneAsync(filter, account);
        }

        public async Task DeleteAccount(Guid accountId)
        {
            var filter = Builders<Account>.Filter.Eq(x => x.Id, accountId);
            await accountsCollection.DeleteOneAsync(filter);
        }

        public async Task AddOrderToAccount(Guid accountId, Order order)
        {
            var filter = Builders<Account>.Filter.Eq(x => x.Id, accountId);
            var update = Builders<Account>.Update.AddToSet(x => x.OrdersListInAccount, order);
            await accountsCollection.UpdateOneAsync(filter, update);
        }
    }
}

