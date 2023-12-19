namespace EventApi.Application.Features.EquipmentSrv.Queries.GetAllAsync
{
    public class GetAllEquipmentVM
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public List<GetAllEquipmentDto> Data { get; set; }
    }
}
