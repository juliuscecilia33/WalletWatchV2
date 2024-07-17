using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using BudgetTrackerAPI.Models; // Ensure this using directive is added

namespace BudgetTrackerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetTrackerController : ControllerBase
    {
        private static BudgetTracker tracker = new BudgetTracker();
        private readonly HttpClient _httpClient;

        public BudgetTrackerController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WalletWatchAPI");
        }

        [HttpGet("transactions")]
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            var response = await _httpClient.GetAsync("/WalletWatchAPI/transactions");
            response.EnsureSuccessStatusCode(); // Throw an exception if the HTTP response status code is unsuccessful

            var transactions = await response.Content.ReadFromJsonAsync<IEnumerable<Transaction>>();
            return transactions;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTransaction([FromBody] Transaction transaction)
        {
            var response = await _httpClient.PostAsJsonAsync("/WalletWatchAPI/add", transaction);
            response.EnsureSuccessStatusCode(); // Throw an exception if the HTTP response status code is unsuccessful

            return Ok();
        }

        [HttpDelete("delete/{index}")]
        public async Task<IActionResult> DeleteTransaction(int index)
        {
            var response = await _httpClient.DeleteAsync($"/WalletWatchAPI/delete/{index}");
            response.EnsureSuccessStatusCode(); // Throw an exception if the HTTP response status code is unsuccessful

            return Ok();
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var response = await _httpClient.GetAsync("/WalletWatchAPI/summary");
            response.EnsureSuccessStatusCode(); // Throw an exception if the HTTP response status code is unsuccessful

            var summary = await response.Content.ReadFromJsonAsync<dynamic>();
            return Ok(summary);
        }
    }
}
