using AzureStorage.Application.Notifications;
using System.Collections.Generic;

namespace AzureStorage.Application.Core
{
    public class BaseResponse
    {
        public dynamic Result { get; set; } = default;

        public IEnumerable<Notification> Notifications { get; set; }
    }
}
