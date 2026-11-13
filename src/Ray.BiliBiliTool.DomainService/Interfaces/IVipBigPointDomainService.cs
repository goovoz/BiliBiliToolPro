using Ray.BiliBiliTool.Agent;
using Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.ApiApi.VipBigPoint;

namespace Ray.BiliBiliTool.DomainService.Interfaces;

public interface IVipBigPointDomainService : IDomainService
{
    Task<VipBigPointCombine> GetCombineAsync(BiliCookie ck);

    Task VipExpressAsync(BiliCookie ck);

    Task SignAsync(BiliCookie ck);

    Task ReceiveDailyMissionsAsync(VipBigPointCombine combine, BiliCookie ck);

    Task ReceiveAndCompleteAsync(
        VipBigPointCombine info,
        string moduleCode,
        string taskCode,
        BiliCookie ck,
        Func<string, BiliCookie, Task<bool>> completeFunc
    );

    Task<bool> CompleteAsync(string taskCode, BiliCookie ck);

    Task<bool> CompleteViewAsync(string taskCode, BiliCookie ck);

    Task<bool> CompleteViewVipMallAsync(string taskCode, BiliCookie ck);

    Task<bool> CompleteV2Async(string taskCode, BiliCookie ck);

    /// <summary>完整观看剧集流程：start 领取观看任务 → 等待倒计时 → 带签名上报完成。</summary>
    Task<bool> CompleteOgvWatchFlowAsync(BiliCookie ck);
}
