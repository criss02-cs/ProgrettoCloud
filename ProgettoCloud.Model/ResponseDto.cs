namespace ProgettoCloud.Model;

public record ResponseDto(string CountryCode, string VatNumber, DateTime RequestDate, bool IsValid, string Name, string Address);