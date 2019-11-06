using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SMR.Tracking.Services
{
    public class SrmTrackingService: ISrmTrackingService
    {
        private readonly HttpClient httpClient;

        public SrmTrackingService(HttpClient httpClient) => this.httpClient = httpClient;


    }
}
