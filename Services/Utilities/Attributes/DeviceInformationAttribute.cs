﻿using Microsoft.AspNetCore.Mvc.Filters;
using Services.Dtos.CheckProfileStatus;
using Services.Features.Interface;

namespace Services.Utilities.Attributes
{
    public class DeviceInformationAttribute : ActionFilterAttribute
    {
        public readonly IServiceAudit _serviceAudit;
        public DeviceInformationAttribute(IServiceAudit serviceAudit)
        {
            _serviceAudit = serviceAudit;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string appVersion = CheckHeaderValue(context, "appVersion") ? context.HttpContext.Request.Headers["appVersion"].ToString() : string.Empty;
            string osVersion = CheckHeaderValue(context, "osversion") ? context.HttpContext.Request.Headers["osversion"].ToString() : string.Empty;
            string isAndoriod = CheckHeaderValue(context, "isAndroid") ? context.HttpContext.Request.Headers["isAndroid"].ToString() : string.Empty;

            ActionLogSqlDto actionLog = new()
            {
                AppVersion = appVersion,
                OsVersion = osVersion,
                IsAndroid = isAndoriod.ToLower() == "true"
            };
            _serviceAudit.AddActionLog(actionLog);
            static bool CheckHeaderValue(ActionExecutingContext context, string value)
            {
                return context.HttpContext.Request.Headers.ContainsKey(value);
            }
        }

    }
}
