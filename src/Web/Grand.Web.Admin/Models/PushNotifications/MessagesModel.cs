﻿using Grand.Infrastructure.Models;

namespace Grand.Web.Admin.Models.PushNotifications;

public class MessagesModel : BaseModel
{
    public int Allowed { get; set; }

    public int Denied { get; set; }
}