using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventApi.Application.Features.CitySrv.Command.CreateCommand
{
    public class CityPostCommand : IRequest<Unit>
    {
        [DeniedValues("mmg",ErrorMessage ="This name is not allowred")]
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
