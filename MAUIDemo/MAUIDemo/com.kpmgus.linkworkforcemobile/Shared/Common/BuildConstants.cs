using System;
using Microsoft.Identity.Client;

namespace com.kpmgus.linkworkforcemobile.Shared.Common
{
    public static class BuildConstants
    {
        //Android
        public static string RedirectURLAndroid { get; set; } = "msauth.com.kpmgus.linkworkforcemobile://auth";
        //iOS
        public static string RedirectURLiOS { get; set; } = "msauth://com.kpmgus.linkworkforcemobile/lFXE55yFacQ0ZcaD5%2F2f7Mm%2BcFQ%3D";
        public static string[] Scopes = { "User.Read" };
        public const string DEV_ClientID = "faea0d60-3376-4803-bd2f-4bcce21a5a22"; //msidentity-samples-testing tenant
        public const string DEV_TenantID = "8ab59120-9090-4240-97e7-2720df205913";
    }
}

