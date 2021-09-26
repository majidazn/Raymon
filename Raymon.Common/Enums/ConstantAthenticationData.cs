using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raymon.Common.Enums
{
    public static class ConstantAthenticationData
    {
        public const string CookieSchema = "Application_EpdHR";
        public const string AccessDeniedPath = "/Error/Index/401";
        public const string LoginPath = "/Login";
        public const string LogoutPath = "/LogOff";
        public const string KeyValue = "epdHR";
        public const string TokenKey = "mbPedKub6v9y_RaymonTokenKey125";
        public const string TokenEncryptionKey = "160EPDEncryptKey";
        public const string ValidIssuer = "http://localhost:7740/";
        public const string ValidAudience = "http://localhost:2658/";
    }
}
