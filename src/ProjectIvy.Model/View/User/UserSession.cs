﻿using System;
using ProjectIvy.Common.Extensions;

namespace ProjectIvy.Model.View.User
{
    public class UserSession
    {
        public UserSession(Database.Main.Security.AccessToken at, bool isCurrentSession)
        {
            Id = at.ValidFrom.ToUnix();
            IpAddress = at.IpAddress;
            IpAddressValue = at.IpAddressValue;
            ValidUntil = at.ValidUntil;
            OperatingSystem = at.OperatingSystem;
            UserAgent = at.UserAgent;
            IsCurrentSession = isCurrentSession;
        }

        public long Id { get; set; }

        public Country.Country Country { get; set; }

        public DateTime ValidUntil { get; set; }

        public string IpAddress { get; set; }

        public long? IpAddressValue { get; set; }

        public bool IsCurrentSession { get; set; }

        public string OperatingSystem { get; set; }

        public string UserAgent { get; set; }
    }
}
