using AutoMapper;
using billing.Data.DTOs.Billing.Invoice;
using billing.Data.DTOs.Masters;
using billing.Data.Models;
using System.Collections.Generic;

namespace billing.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<MstUser, UserDTO>();
            CreateMap<MstUserRole, UserRoleDTO>();
            CreateMap<MstService, ServiceDTO>();
            CreateMap<MstCustomer, CustomerDTO>();
            CreateMap<billing.Data.Models.Invoice,InvoiceDTO>();
            CreateMap<billing.Data.Models.Invoice, InvoiceListDTO>();
            CreateMap<InvoiceItem, InvoiceItemDTO>();


            // DTO to Entity
            CreateMap<UserDTO, MstUser>();
            CreateMap<UserRoleDTO, MstUserRole>();
            CreateMap<ServiceDTO, MstService>();
            CreateMap<CustomerDTO, MstCustomer>();
            CreateMap<InvoiceDTO, billing.Data.Models.Invoice>();
            CreateMap<InvoiceListDTO, billing.Data.Models.Invoice>();
            CreateMap<InvoiceItemDTO, InvoiceItem>();


        }
    }
}