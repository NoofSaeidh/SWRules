using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noofs.SWRules
{
    public static class AppServiceExtensions
    {
        public static async Task<TEntityDto> Get<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>(
            this AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>> service,
            TPrimaryKey key
        )
            where TEntity : class, IEntity<TPrimaryKey>
            where TEntityDto : IEntityDto<TPrimaryKey>
            where TUpdateInput : IEntityDto<TPrimaryKey>
        {
            return await service.Get(new EntityDto<TPrimaryKey>(key));
        }

        public static async Task<TEntityDto> Get<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>(
           this AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>> service,
           TPrimaryKey? key
        )
            where TEntity : class, IEntity<TPrimaryKey>
            where TEntityDto : IEntityDto<TPrimaryKey>
            where TUpdateInput : IEntityDto<TPrimaryKey>
            where TPrimaryKey : struct
        {
            return await service.Get(new EntityDto<TPrimaryKey>(key ?? default));
        }

        public static async Task Delete<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>(
           this AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>> service,
            TPrimaryKey key
        )
            where TEntity : class, IEntity<TPrimaryKey>
            where TEntityDto : IEntityDto<TPrimaryKey>
            where TUpdateInput : IEntityDto<TPrimaryKey>
        {
            await service.Delete(new EntityDto<TPrimaryKey>(key));
        }

        public static async Task Delete<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>(
           this AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>> service,
           TPrimaryKey? key
        )
            where TEntity : class, IEntity<TPrimaryKey>
            where TEntityDto : IEntityDto<TPrimaryKey>
            where TUpdateInput : IEntityDto<TPrimaryKey>
            where TPrimaryKey : struct
        {
            await service.Delete(new EntityDto<TPrimaryKey>(key ?? default));
        }
    }
}
