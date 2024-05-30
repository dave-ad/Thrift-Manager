using ThriftManager.DTO.Common;

namespace ThriftManager.DTO.Responses;

public class MemberIdResponse : IServiceResponse
{
    public int MemberId { get; set; } = 0;
}
