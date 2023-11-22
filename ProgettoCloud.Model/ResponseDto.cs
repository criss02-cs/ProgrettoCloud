namespace ProgettoCloud.Model;

public record ResponseDto(string CountryCode, string VatNumber, DateTime RequestDate, bool Valid, string Name, string Address);