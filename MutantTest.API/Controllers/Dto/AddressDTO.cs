using MutantTest.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace MutantTest.API.Controllers.Dto
{
    public class AddressDTO
    {
        public string street { get; set; }

        [Required]
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public GeoDTO geo { get; set; }

        public AddressDTO() {}

        public AddressDTO(Address address)
        {
            street = address.Street;
            suite = address.Suite;
            city = address.City;
            zipcode = address.Zipcode;
            geo = new GeoDTO(address.Geo);
        }

        public Address ToAddress() => new Address
        { 
            Street = street,
            Suite = suite,
            City = city,
            Zipcode = zipcode,
            Geo = geo.ToGeo()
        };
                        
    }
}
