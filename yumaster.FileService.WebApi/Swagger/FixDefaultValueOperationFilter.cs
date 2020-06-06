﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.ComponentModel;
using System.Linq;

namespace yumaster.FileService.WebApi.Swagger
{
    /// <summary>
    /// 截止Swashbuckle 1.0.0-rc3
    /// 修复 DefaultValue属性标记的参数不会有默认值效果
    /// </summary>
    public class FixDefaultValueOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            foreach (var pd in context.ApiDescription.ParameterDescriptions)
            {
                var attrDefVal = (pd.ModelMetadata as DefaultModelMetadata)?.Attributes?.PropertyAttributes
                    ?.FirstOrDefault(p => p.GetType() == typeof(DefaultValueAttribute)) as DefaultValueAttribute;
                IParameter op;
                if (attrDefVal != null &&
                    (op = operation.Parameters.FirstOrDefault(p => p.Name.Equals(pd.Name, StringComparison.OrdinalIgnoreCase))) != null)
                {
                    ((PartialSchema)op).Default = attrDefVal.Value;
                }
            }
        }
    }
}
