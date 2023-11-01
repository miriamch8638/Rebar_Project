using MongoDB.Driver;
using RebarProject3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RebarProject3.DataAccess
{
    public class AccountDataAccess : DataAccess
    {

        Dailyreport dailyReport = new Dailyreport();

        Account Account = new Account();
        public async Task AddDailyReport(string password)
        {
            if (password == dailyReport.ManagerPassword)
            {
                var ordersCollection = ConnectToMongo<OrderDB>("Order");
                var filter = Builders<OrderDB>.Filter.Eq(x => x.OrderCreateTime, dailyReport.date);
                var orderList = await ordersCollection.Find(filter).ToListAsync();
                Account.OrdersListInAccount.AddRange(orderList);
                Account.GetToatlPrice();
                dailyReport.SumOrders = orderList.Count();
                dailyReport.SumMoney = Account.TotalPriceAllOrders;
                var dailyReportCollection = ConnectToMongo<Dailyreport>("DailyReport");
                _ = dailyReportCollection.InsertOneAsync(dailyReport);
            }
        }
        public async Task<List<Dailyreport>> GetDailyReport()
        {
            var menuCollection = ConnectToMongo<Dailyreport>("DailyReport");
            var result = await menuCollection.FindAsync(_ => true);
            return result.ToList();
        }

    }

}


