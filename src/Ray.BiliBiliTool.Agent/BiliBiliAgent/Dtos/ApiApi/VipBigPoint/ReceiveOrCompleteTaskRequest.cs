namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.ApiApi.VipBigPoint;

public class ReceiveOrCompleteTaskRequest
{
    public ReceiveOrCompleteTaskRequest(string taskCode)
    {
        TaskCode = taskCode;
    }

    public string TaskCode { get; set; }
}
/// <summary>
/// 领取任务（App 请求版）：receive/v2 对部分 task_code（如 ogvwatchnew）校验客户端版本信号，
/// 桌面 UA + 仅 taskCode 会返回 6007000；body 携带 build 等 BaseAppRequest 字段即可通过。
/// 仅用于 VipBigPointReceiveV2。
/// </summary>
public class ReceiveOrCompleteTaskAppRequest : BaseAppRequest
{
    public ReceiveOrCompleteTaskAppRequest(string taskCode)
    {
        TaskCode = taskCode;
    }

    public string TaskCode { get; set; }
}
