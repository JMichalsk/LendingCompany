using AutoMapper;
using LendingCompany.BL.Model;
using LendingCompany.BL.Model.Dtos;

namespace LendingCompany.BL.Mappings
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Payment, PaymentDto>();
        }
    }
}
