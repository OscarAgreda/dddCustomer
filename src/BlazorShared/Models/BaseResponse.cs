using System;

namespace BlazorShared.Models
{
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationId)
        {
            _correlationId = correlationId;
        }

        public BaseResponse()
        {
        }
    }
}