using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuropeanVatCheckService;
using ProgettoCloud.Model;

namespace ProgettoCloud.Service
{
    public class CheckVatService
    {
        private readonly checkVatPortTypeClient _client = new();

        public async Task<ResponseDto> CheckVat(RequestDto request)
        {
            var req = new checkVatRequest(request.CountryCode, request.VatNumber);
            var response = await _client.checkVatAsync(req);
            return new ResponseDto(response.countryCode, response.vatNumber, response.requestDate, response.valid,
                response.name, response.address);
        }
    }
}
