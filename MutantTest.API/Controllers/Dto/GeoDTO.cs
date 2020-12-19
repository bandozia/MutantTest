using MutantTest.Domain.Model;

namespace MutantTest.API.Controllers.Dto
{
    public class GeoDTO 
    {
        public decimal lat { get; set; }
        public decimal lng { get; set; }

        public GeoDTO() {}

        public GeoDTO(Geo geo)
        {
            lat = geo.Lat;
            lng = geo.Lng;
        }

        public Geo ToGeo() => new Geo
        { 
            Lat = lat,
            Lng = lng
        };
    }
}
