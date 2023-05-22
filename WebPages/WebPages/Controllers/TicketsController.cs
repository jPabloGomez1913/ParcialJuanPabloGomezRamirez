﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParcialJuanPabloGomezRamirez.DAL.Entities;
using System.Text.Json.Serialization;

namespace WebPages.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public TicketsController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var url = "https://localhost:7096/api/Tickets/Get";
            var json = await _httpClient.CreateClient().GetStringAsync(url);
            List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
            return View(tickets);
        }

        /*[HttpGet, ActionName("Get")]
        [Route("Get/{id}")]

        public async Task<IActionResult> GetTicketById()
        {

        }*/
    }
}
