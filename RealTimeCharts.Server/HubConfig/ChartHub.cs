﻿using Microsoft.AspNetCore.SignalR;
using RealTimeCharts.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealTimeCharts.Server.HubConfig
{
    public class ChartHub : Hub
    {
        public async Task BroadcastChartData(List<ChartsModel> data) =>
            await Clients.All.SendAsync("broadcastchartdata", data);
    }
}
