﻿using Authentication.Facebook;
using Grand.Infrastructure;
using Grand.Infrastructure.Plugins;

[assembly: PluginInfo(
    FriendlyName = "Facebook authentication",
    Group = "Authentication methods",
    SystemName = FacebookAuthenticationDefaults.ProviderSystemName,
    SupportedVersion = GrandVersion.SupportedPluginVersion,
    Author = "grandnode team",
    Version = "2.1.1"
)]