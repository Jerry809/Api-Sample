﻿using EFHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ApiSample.Utility.Hooks.UpdateSystemInfo
{
    public class UpdateSystemInfoPreInsertHook : PreInsertHook<ISystemInfo>
    {
        public HttpContextBase HttpContext { get; set; }

        public UpdateSystemInfoPreInsertHook(HttpContextBase httpContext)
        {
            this.HttpContext = httpContext;
        }

        public override void Hook(ISystemInfo entity, HookEntityMetadata metadata)
        {
            var userName = "Unlogin";
            if (this.HttpContext != null)
            {
                userName = this.HttpContext.User.Identity.Name;
            }

            entity.CreatedBy = userName;
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedBy = userName;
            entity.UpdatedAt = DateTime.Now;
        }

        public override bool RequiresValidation
        {
            get { return false; }
        }
    }
}
